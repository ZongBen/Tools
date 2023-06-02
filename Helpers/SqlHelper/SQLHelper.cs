using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DBproviderUtility;

namespace BenLai.SqlUtility
{
    public class SqlHelper
    {
        private SqlConnection Connection { get; }
        private DBTransaction DBTrans { get; set; }
        public SqlHelper(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }
        public SqlHelper(string ConnectionString, DBTransaction DBTrans)
        {
            Connection = new SqlConnection(ConnectionString);
            DBTrans.Con = Connection;
            this.DBTrans = DBTrans;
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
                Connection.Open();
                if(DBTrans != null)
                {
                    cmd.Transaction = Connection.BeginTransaction();
                    DBTrans.Trans = cmd.Transaction;
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

    public class DBTransaction : IDBTransaction
    {
        internal SqlTransaction Trans { get; set; }
        internal SqlConnection Con { get; set; }
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
}
