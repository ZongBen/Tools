using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using BenLai.SharedHelper.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BenLai.SharedHelper;

namespace BenLai.SqlUtility
{
    /// <summary>
    /// 建立資料庫連線與交易。
    /// </summary>
    public class SqlHelper : IDBOperator, IDBTransaction
    {
        private SqlConnection Connection { get; }
        private DBTransaction DBTrans { get; }
        /// <summary>
        /// 初始化資料庫連線及交易。
        /// </summary>
        /// <param name="ConnectionString">資料庫連接字串</param>
        /// <param name="EnabledTransaction">啟用資料庫交易，True: 啟用、False: 停用</param>
        public SqlHelper(string ConnectionString, bool EnabledTransaction)
        {
            Connection = new SqlConnection(ConnectionString);
            if (EnabledTransaction)
            {
                DBTrans = new DBTransaction() { 
                    Con = Connection
                };
            }
        }
        /// <summary>
        /// 執行SQL指令，回傳強型別資料列。
        /// </summary>
        /// <typeparam name="T">資料類別</typeparam>
        /// <param name="Command">SQL指令</param>
        /// <param name="objParameters">SQL指令參數</param>
        /// <returns>強型別資料列。</returns>
        public IList<T> ExecuteList<T>(string Command, SqlHelperParameters objParameters) where T : class, new()
        {     
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }
                if (DBTrans != null)
                {
                    da.SelectCommand.Transaction = DBTrans.Trans = DBTrans.Trans ?? Connection.BeginTransaction();
                }
                da.SelectCommand.Parameters.AddRange(objParameters.SqlHelperParameter.ToArray());
                da.Fill(dt);
                da.SelectCommand.Parameters.Clear();
                if (DBTrans == null)
                {
                    Connection.Close();
                }
            }
            IList<T> result = new List<T>();
            foreach (DataRow row in dt.Rows)
            { 
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
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
        /// <summary>
        /// 執行SQL指令，回傳受影響的資料列數目。
        /// </summary>
        /// <param name="Command">SQL指令</param>
        /// <param name="objParameters">SQL指令參數</param>
        /// <returns>受影響的資料列數目。</returns>
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
                    cmd.Transaction = DBTrans.Trans = DBTrans.Trans ?? Connection.BeginTransaction();
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
        /// <summary>
        /// 執行SQL指令，回傳第一列弱型別資料列。
        /// </summary>
        /// <param name="Command">SQL指令</param>
        /// <param name="objParameters">SQL指令參數</param>
        /// <returns>第一列弱型別資料列。</returns>
        public IList<object> ExecuteObjList(string Command, SqlHelperParameters objParameters)
        {
            using(DataTable dt = new DataTable())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(Command, Connection))
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    if (DBTrans != null)
                    {
                        da.SelectCommand.Transaction = DBTrans.Trans = DBTrans.Trans ?? Connection.BeginTransaction();
                    }
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

        public IDBModel<T> GetByKey<T>(T Model) where T : class, new()
        {
            StringBuilder SbSql = new StringBuilder();
            SqlHelperParameters param = new SqlHelperParameters();
            SbSql.Append("SELECT" + Environment.NewLine);
            SbSql.Append("	*" + Environment.NewLine);
            SbSql.Append($"FROM {typeof(T).Name}" + Environment.NewLine);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            foreach (var prop in typeof(T).GetProperties())
            {
                if(prop.GetCustomAttribute<KeyAttribute>() != null)
                {
                    SbSql.Append($"AND {prop.Name} = @{prop.Name}");
                    param.Add($"@{prop.Name}", prop.GetValue(Model));
                }
            }
            var model_list = ExecuteList<T>(SbSql.ToString(), param);
            if(model_list.Count > 1)
            {
                throw new Exception("查詢到多筆資料");
            }
            return new DBModel<T>() { Model = model_list.Count == 1 ? model_list[0] : null };
        }

        public int Insert<T>(T Model) where T : class, new()
        {
            SqlHelperParameters param = new SqlHelperParameters();
            StringBuilder SbCol = new StringBuilder();
            StringBuilder SbVal = new StringBuilder();
            foreach (var prop in typeof(T).GetProperties())
            {
                if(prop.GetCustomAttribute<IdentityAttribute>() != null)
                {
                    continue;
                }
                SbCol.Append($", {prop.Name}");
                SbVal.Append($", @{prop.Name}");
                param.Add($"@{prop.Name}", prop.GetValue(Model));
            }
            string sqlQuery = BuildInsertSql(typeof(T).Name, SbCol.ToString().Remove(0, 2), SbVal.ToString().Remove(0, 2));
            return ExecuteNonQuery(sqlQuery, param);
        }

        public int Update<T>(IDBModel<T> dbModel, Action<T> action = null) where T : class, new()
        {
            if(action != null)
            {
                action.Invoke(dbModel.Model);
            }
            SqlHelperParameters param = new SqlHelperParameters();
            StringBuilder SbUpd = new StringBuilder();
            StringBuilder SbKey = new StringBuilder();
            foreach(var prop in typeof(T).GetProperties())
            {
                if (prop.GetCustomAttribute<KeyAttribute>() != null)
                {
                    SbKey.Append($"AND {prop.Name} = @{prop.Name}");
                    param.Add($"@{prop.Name}", prop.GetValue(dbModel.Model));
                    continue;
                }
                if (prop.GetCustomAttribute<IdentityAttribute>() != null)
                {
                    continue;
                }
                SbUpd.Append($",{prop.Name} = @{prop.Name}" + Environment.NewLine);
                param.Add($"@{prop.Name}", prop.GetValue(dbModel.Model));
            }
            string sqlQuery = BuildUpdSql(typeof(T).Name, SbUpd.ToString().Remove(0, 1), SbKey.ToString());
            return ExecuteNonQuery(sqlQuery, param);
        }

        public int Delete<T>(T Model) where T : class, new()
        {
            StringBuilder SbDel = new StringBuilder();
            SqlHelperParameters param = new SqlHelperParameters();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.GetCustomAttribute<KeyAttribute>() != null)
                {
                    SbDel.Append($"AND {prop.Name} = @{prop.Name}");
                    param.Add($"@{prop.Name}", prop.GetValue(Model));
                }
            }
            string sqlQueyr = BuildDelSql(typeof(T).Name, SbDel.ToString());
            return ExecuteNonQuery(sqlQueyr, param);
        }
        /// <summary>
        /// 承認資料庫交易，並關閉連線。
        /// </summary>
        public void Commit()
        {
            DBTrans.Commit();
        }
        /// <summary>
        /// 回復資料庫交易，並關閉連線。
        /// </summary>
        public void Rollback()
        {
            DBTrans.Rollback();
        }

        private string BuildDelSql(string TableName, string Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new Exception("唯一鍵值不可為空");
            }
            StringBuilder SbSql = new StringBuilder();
            SbSql.Append($"DELETE FROM {TableName}" + Environment.NewLine);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            SbSql.Append(Key);
            return SbSql.ToString();
        }

        private string BuildUpdSql(string TableName, string ColVal, string Key)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new Exception("唯一鍵值不可為空");
            }
            StringBuilder SbSql = new StringBuilder();
            SbSql.Append($"UPDATE {TableName}" + Environment.NewLine);
            SbSql.Append("SET" + Environment.NewLine);
            SbSql.Append(ColVal);
            SbSql.Append("WHERE 1=1" + Environment.NewLine);
            SbSql.Append(Key);
            return SbSql.ToString();
        }

        private string BuildInsertSql(string TableName, string Col, string Val)
        {
            StringBuilder SbSql = new StringBuilder();
            SbSql.Append($"INSERT INTO {TableName}" + Environment.NewLine);
            SbSql.Append("(");
            SbSql.Append(Col);
            SbSql.Append(")" + Environment.NewLine);
            SbSql.Append("VALUES" + Environment.NewLine);
            SbSql.Append("(");
            SbSql.Append(Val);
            SbSql.Append(")");
            return SbSql.ToString();
        }
    }
    /// <summary>
    /// 建立SQL指令參數合集
    /// </summary>
    public class SqlHelperParameters
    {
        internal List<SqlParameter> SqlHelperParameter { get; }
        public SqlHelperParameters()
        {
            SqlHelperParameter = new List<SqlParameter>();
        }
        /// <summary>
        /// 新增SQL指令參數。
        /// </summary>
        /// <param name="express">參數名稱</param>
        /// <param name="value">參數數值</param>
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
        public void Rollback()
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
