using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using System.IO;
using ParametersLayer;
using DataAccessLayer;
using DataAccessLayer.Interface;

namespace ServiceLayer
{
    public class ClassService : IClassService
    {
        private readonly IDBProvider _Provider;
        public ClassService()
        {
            _Provider = new DBProvider();
        }

        public void AutoCode(string TableName, string FolderPath, string ConnectStr)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            FolderPath += $"\\{TableName}.cs";
            StreamWriter sw = File.CreateText(FolderPath);
            StringBuilder sb = new StringBuilder();
            IList<TableColumns> tableColumns = _Provider.GetTableColumns(TableName, ConnectStr);

            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Collections.Generic;" + Environment.NewLine);
            //sb.Append("using System.ComponentModel.DataAnnotations;" + Environment.NewLine);
            sb.Append("" + Environment.NewLine);
            sb.Append("namespace ParametersLayer" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append($"    public class {TableName}" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            foreach (var Col in tableColumns)
            {
                /*
                if(Col.Is_PrimaryKey == "YES")
                {
                    sb.Append("[Required]" + Environment.NewLine);
                }
                if (!Convert.IsDBNull(Col.Max_Length))
                {
                    sb.Append($"[StringLength({Col.Max_Length})]" + Environment.NewLine);
                }
                */
                sb.Append($"        public {ChangeType(Col.Data_Type)}");
                if (Col.Is_Nullable == "YES")
                {
                    sb.Append("?");
                }
                sb.Append($" {Col.Column_Name} {{ get; set; }}" + Environment.NewLine);
            }
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
        }

        private string ChangeType(string DB_Type)
        {
            string result;
            switch (DB_Type)
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    result = "string";
                    break;
                case "int":
                    result = "int";
                    break;
                case "decimal":
                    result = "decimal";
                    break;
                case "float":
                    result = "double";
                    break;
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    result = "DateTime";
                    break;
                case "varbinary":
                case "binary":
                    result = "byte[]";
                    break;
                default:
                    result = "object";
                    break;
            }
            return result;
        }
    }
}
