using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParametersLayer;
using System.Diagnostics;

namespace ServiceLayer
{
    public class CommonService : ICommonService
    {
        public void OpenFoder(string FolderPath)
        {
            Process.Start(FolderPath);
        }
        public Point CenterLocation(Form ChildForm, Form ParentForm)
        {
            int CenterX = ChildForm.Location.X + ChildForm.Width / 2;
            int CenterY = ChildForm.Location.Y + ChildForm.Height / 2;
            return new Point(CenterX - ParentForm.Width / 2, CenterY - ParentForm.Height / 2);
        }

        public string CodeClass(string ClassName, List<TableColumns> model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Collections.Generic;" + Environment.NewLine);
            sb.Append("using System.ComponentModel.DataAnnotations;" + Environment.NewLine);
            sb.Append("using System.ComponentModel;" + Environment.NewLine);
            sb.Append("" + Environment.NewLine);
            sb.Append("namespace TemplateModel" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append($"    public class {ClassName}" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            foreach (var Col in model)
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
                sb.Append(@"        /// <summary>" + Environment.NewLine);
                sb.Append(@"        /// " + Col.Column_Description + Environment.NewLine);
                sb.Append(@"        /// </summary>" + Environment.NewLine);
                sb.Append($"        [DisplayName(\"{Col.Column_Description}\")]" + Environment.NewLine);
                sb.Append($"        public {ChangeType(Col.Data_Type)}");
                if (Col.Is_Nullable == "YES" && ChangeType(Col.Data_Type) != "string")
                {
                    sb.Append("?");
                }
                sb.Append($" {Col.Column_Name} {{ get; set; }}" + Environment.NewLine);
            }
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);
            return sb.ToString();
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
                case "time":
                    result = "TimeSpan";
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
