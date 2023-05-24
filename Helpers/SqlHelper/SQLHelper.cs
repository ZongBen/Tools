using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace BenLai.SqlUtility
{
    public class SqlHelper
    {
        private SqlConnection Connection { get; }
        public SqlHelper(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }
        public IList<T> ExecuteList<T>(string Command, SqlHelperParameters objParameters) where T : class, new()
        {     
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
            {
                da.SelectCommand.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                da.Fill(dt);
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

        public async Task<IList<T>> ExecuteListAsync<T>(string Command, SqlHelperParameters objParameters) where T : class, new()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
            {
                da.SelectCommand.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                await Task.Run(() => da.Fill(dt));
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
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch
                {
                    Connection.Close();
                    throw;
                }
                finally
                {
                    Connection.Close();
                }
                return result;
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string Command, SqlHelperParameters objParameters)
        {
            using (SqlCommand cmd = new SqlCommand(Command, Connection))
            {
                int result;
                cmd.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                Connection.Open();
                try
                {
                    result = await Task.Run(() => cmd.ExecuteNonQuery());
                }
                catch
                {
                    Connection.Close();
                    throw;
                }
                finally
                {
                    Connection.Close();
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
}
