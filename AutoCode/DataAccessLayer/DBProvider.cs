using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using ParametersLayer;
using SqlUtility;

namespace DataAccessLayer
{
    public class DBProvider : IDBProvider
    {
        public IList<TableColumns> GetTableColumns(string TableName, string Constr)
        {
            SqlHelper helper = new SqlHelper(Constr);
            StringBuilder SbSql = new StringBuilder();
            SqlHelperParameters parameters = new SqlHelperParameters();
            SbSql.Append("SELECT" + Environment.NewLine);
            SbSql.Append("	isc.column_name AS 'Column_Name'" + Environment.NewLine);
            SbSql.Append("   ,isc.data_type AS 'Data_Type'" + Environment.NewLine);
            SbSql.Append("   ,isc.character_maximum_length AS 'Max_Length'" + Environment.NewLine);
            SbSql.Append("   ,isc.IS_NULLABLE AS 'Is_Nullable'" + Environment.NewLine);
            SbSql.Append("   ,iccu.Is_PrimaryKey" + Environment.NewLine);
            SbSql.Append("FROM information_schema.columns isc" + Environment.NewLine);
            SbSql.Append("LEFT JOIN (SELECT" + Environment.NewLine);
            SbSql.Append("		TABLE_NAME" + Environment.NewLine);
            SbSql.Append("	   ,Column_Name" + Environment.NewLine);
            SbSql.Append("	   ,'YES' AS Is_PrimaryKey" + Environment.NewLine);
            SbSql.Append("	FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE) iccu" + Environment.NewLine);
            SbSql.Append("	ON iccu.TABLE_NAME = isc.TABLE_NAME" + Environment.NewLine);
            SbSql.Append("		AND iccu.Column_Name = isc.Column_Name" + Environment.NewLine);
            SbSql.Append("WHERE isc.table_name = @TableName" + Environment.NewLine);
            parameters.Add("@TableName", TableName);
            return helper.ExecuteList<TableColumns>(SbSql.ToString(), parameters);
        }
    }
}
