using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SharedHelper.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BenLai.SqlUtility
{
    public class SqlHelper : IDBOperator, IDBTransaction
    {
        private SqlConnection Connection { get; }
        private DBTransaction DBTrans { get; set; }
        public SqlHelper(string ConnectionString, bool ExecuteTransaction)
        {
            Connection = new SqlConnection(ConnectionString);
            if (ExecuteTransaction)
            {
                DBTrans = new DBTransaction() { 
                    Con = Connection
                };
            }
        }

        public IList<T> ExecuteList<T>(string Command, SqlHelperParameters objParameters) where T : class, new()
        {     
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
            {
                da.SelectCommand.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                da.Fill(dt);
                da.SelectCommand.Parameters.Clear();
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            IList<T> result = new List<T>();
            foreach (DataRow row in dt.Rows)
            { 
                T item = new T();
                foreach (var prop in properties)
                {
                    if (!dt.Columns.Contains(prop.Name))
                    {
                        continue;
                    }
                    var value = row[prop.Name];
                    if (Convert.IsDBNull(value))
                    {
                        value = prop.PropertyType == typeof(string) ? string.Empty : null;
                    }
                    prop.SetValue(item, value);
                }
                result.Add(item);
            }
            return result;
        }

        public int ExecuteNonQuery(string Command, SqlHelperParameters objParameters)
        {
            using (SqlCommand cmd = new SqlCommand(Command, Connection))
            {
                int result;
                cmd.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                if(Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                if(DBTrans != null)
                {
                    if(DBTrans.Trans == null)
                    {
                        DBTrans.Trans = Connection.BeginTransaction();
                    }
                    cmd.Transaction = DBTrans.Trans;
                }
                try
                {
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if(DBTrans == null)
                    {
                        Connection.Close();
                    }
                }
                return result;
            }
        }

        public IList<object> ExecuteObjList(string Command, SqlHelperParameters objParameters)
        {
            using(DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
                {
                    da.SelectCommand.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                    da.Fill(dt);
                    da.SelectCommand.Parameters.Clear();
                    IList<object> result = new List<object>();
                    foreach(DataRow row in dt.Rows)
                    {
                        result.Add(row[0]);
                    }
                    return result;
                }
            }
        }

        public IDBModel<T> Get<T>(T Model) where T : class, new()
        {
            StringBuilder SbSql = new StringBuilder();
            SqlHelperParameters param = new SqlHelperParameters();
            SbSql.Append("SELECT" + Environment.NewLine);
            SbSql.Append("	*" + Environment.NewLine);
            SbSql.Append($"FROM {typeof(T).Name}" + Environment.NewLine);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            int index = 0;
            foreach (var prop in typeof(T).GetProperties())
            {
                if(prop.GetCustomAttribute<KeyAttribute>() != null)
                {
                    SbSql.Append($"AND {prop.Name} = @key_value_{index}");
                    param.Add($"@key_value_{index}", prop.GetValue(Model));
                    index++;
                }
            }
            var model_list = ExecuteList<T>(SbSql.ToString(), param);
            if(model_list.Count > 1)
            {
                throw new Exception("查詢到多筆資料");
            }
            return new DBModel<T>() { Model = model_list.Count == 1 ? model_list[0] : null };
        }

        public void Commit()
        {
            DBTrans.Commit();
        }
        public void RollBack()
        {
            DBTrans.RollBack();
        }
    }

    public class SqlHelperParameters
    {
        internal List<SqlParameter> SqlHelperParameter { get; }
        public SqlHelperParameters()
        {
            SqlHelperParameter = new List<SqlParameter>();
        }
        public void Add(string express, object value)
        {
            SqlHelperParameter.Add(new SqlParameter()
            {
                ParameterName = express,
                Value = value ?? Convert.DBNull
            });
        }
    }
    
    internal class DBTransaction : IDBTransaction
    {
        public SqlTransaction Trans { get; set; }
        public SqlConnection Con { get; set; }
        public void Commit()
        {
            Trans.Commit();
            Con.Close();
        }
        public void RollBack()
        {
            Trans.Rollback();
            Con.Close();
        }
    }

    internal class DBModel<T> : IDBModel<T>
    {
        public T Model { get; set; }
    }
}
