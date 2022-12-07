using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;
using System.IO;
using ServiceLayer.Interface;
using ParametersLayer;
using System.Drawing;

namespace ServiceLayer
{
    public class SchemaService : ISchemaService
    {
        public Workbook LoadExcel(string FilePath)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(FilePath);
            return book;
        }

        public string ExportExcelTemplate(string OutputPath)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
            OutputPath += "\\資料庫文件.xlsx";

            string FontName = "新細明體";
            int FontSize = 12;
            Workbook book = new Workbook();
            book.Worksheets.Clear();
            Worksheet sheet = book.CreateEmptySheet("資料表名稱");
            sheet["A1"].Text = "英文名稱";
            sheet["B1"].Text = "中文名稱";
            sheet["C1"].Text = "資料型態";
            sheet["D1"].Text = "資料長度";
            sheet["E1"].Text = "IsNullable(Y/N)";
            sheet["F1"].Text = "IsPKey(Y/N)";
            sheet["G1"].Text = "IsIdentity(Y/N)";
            sheet["H1"].Text = "預設值(文字需加引號)";
            sheet["A1:H1"].ColumnWidth = 26;
            sheet["A1:H1"].Style.Color = Color.FromArgb(169, 208, 142);
            sheet["A1:H1"].Style.Font.FontName = FontName;
            sheet["A1:H1"].Style.Font.Size = FontSize;
            sheet["A1:H1"].Style.HorizontalAlignment = HorizontalAlignType.Center;
            sheet["A1:H1"].Style.VerticalAlignment = VerticalAlignType.Center;

            var DemoData = GetDemoData();
            int initialRow = 2;
            foreach (var item in DemoData)
            {
                sheet[$"A{initialRow}:H{initialRow}"].Style.Font.FontName = FontName;
                sheet[$"A{initialRow}:H{initialRow}"].Style.Font.Size = FontSize;
                sheet[$"A{initialRow}:H{initialRow}"].Style.HorizontalAlignment = HorizontalAlignType.Center;
                sheet[$"A{initialRow}:H{initialRow}"].Style.VerticalAlignment = VerticalAlignType.Center;

                sheet[initialRow, 1].Text = item.ColumnEName ?? "";
                sheet[initialRow, 2].Text = item.ColumnCName ?? "";
                sheet[initialRow, 3].Text = item.DataType ?? "";
                sheet[initialRow, 4].Text = item.DataLength ?? "";
                sheet[initialRow, 5].Text = item.IsNullable ?? "";
                sheet[initialRow, 6].Text = item.IsPKey ?? "";
                sheet[initialRow, 7].Text = item.IsIdentity ?? "";
                sheet[initialRow, 8].Text = item.DefaultValue ?? "";
                initialRow++;
            }
            string Message = string.Empty;
            try
            {
                File.Create(OutputPath).Close();
                book.SaveToFile(OutputPath);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
        public string CreateTable(Worksheet sheet)
        {
            var SchemaList = GetSchemaList(sheet);
            StringBuilder SbDS = new StringBuilder();
            StringBuilder SbSql = new StringBuilder();
            SbSql.Append($"CREATE TABLE {sheet.Name} (" + Environment.NewLine);
            foreach(var item in SchemaList)
            {
                SbSql.Append($"  {item.ColumnEName} {item.DataType}");
                if (!string.IsNullOrEmpty(item.DataLength))
                {
                    SbSql.Append($"({item.DataLength})");
                }
                if (item.IsNullable == "N")
                {
                    SbSql.Append(" NOT NULL");
                }
                if (item.IsIdentity == "Y")
                {
                    SbSql.Append(" IDENTITY(1,1)");
                }
                if (!string.IsNullOrEmpty(item.DefaultValue))
                {
                    SbSql.Append($" DEFAULT {item.DefaultValue}");
                }
                SbSql.Append("," + Environment.NewLine);

                SbDS.Append($"EXEC sp_addextendedproperty 'MS_Description', '{item.ColumnCName}', 'SCHEMA', 'dbo', 'table', '{sheet.Name}', 'COLUMN', '{item.ColumnEName}'" + Environment.NewLine);
            }

            StringBuilder SbPKey = new StringBuilder();
            var PkeyList = SchemaList.Where(x => x.IsPKey == "Y").Select(x => x.ColumnEName).ToArray();
            foreach (var item in PkeyList)
            {
                SbPKey.Append($",{item}");
            }
            if(PkeyList.Length > 0)
            {
                SbSql.Append($"CONSTRAINT pk_{sheet.Name} PRIMARY KEY (@PKey)" + Environment.NewLine);
                SbSql = SbSql.Replace("@PKey", SbPKey.ToString().Remove(0, 1));
            }
            SbSql.Append(");" + Environment.NewLine);
            SbSql.Append(SbDS.ToString());
            return SbSql.ToString();
        }

        public string AddCol(string TableName, IList<Schema> SchemaList)
        {
            StringBuilder SbSql = new StringBuilder();
            StringBuilder SbDS = new StringBuilder();
            foreach (var item in SchemaList)
            {
                SbSql.Append($"ALTER TABLE {TableName} ADD {item.ColumnEName} {item.DataType}");
                if (!string.IsNullOrEmpty(item.DataLength))
                {
                    SbSql.Append($"({item.DataLength})");
                }
                if (item.IsNullable == "N")
                {
                    SbSql.Append(" NOT NULL");
                }
                if (item.IsIdentity == "Y")
                {
                    SbSql.Append(" IDENTITY(1,1)");
                }
                if (!string.IsNullOrEmpty(item.DefaultValue))
                {
                    SbSql.Append($" DEFAULT {item.DefaultValue}");
                }
                /*
                if(item.IsPKey == "Y")
                {
                    SbSql.Append(" PRIMARY KEY");
                }
                */
                SbSql.Append(";" + Environment.NewLine);
                SbDS.Append($"EXEC sp_addextendedproperty 'MS_Description', '{item.ColumnCName}', 'SCHEMA', 'dbo', 'table', '{TableName}', 'COLUMN', '{item.ColumnEName}'" + Environment.NewLine);
            }
            SbSql.Append(SbDS.ToString());
            return SbSql.ToString();
        }

        public string AlterCol(string TableName, IList<Schema> SchemaList)
        {
            StringBuilder SbSql = new StringBuilder();
            StringBuilder SbDS = new StringBuilder();
            foreach (var item in SchemaList)
            {
                SbSql.Append($"ALTER TABLE {TableName} ALTER COLUMN {item.ColumnEName} {item.DataType}");
                if (!string.IsNullOrEmpty(item.DataLength))
                {
                    SbSql.Append($"({item.DataLength})");
                }
                if (item.IsNullable == "N")
                {
                    SbSql.Append(" NOT NULL");
                }
                if (item.IsIdentity == "Y")
                {
                    SbSql.Append(" IDENTITY(1,1)");
                }
                if (!string.IsNullOrEmpty(item.DefaultValue))
                {
                    SbSql.Append($" DEFAULT {item.DefaultValue}");
                }
                /*
                if(item.IsPKey == "Y")
                {
                    SbSql.Append(" PRIMARY KEY");
                }
                */
                SbSql.Append(";" + Environment.NewLine);
                SbDS.Append($"EXEC sp_updateextendedproperty 'MS_Description', '{item.ColumnCName}', 'SCHEMA', 'dbo', 'table', '{TableName}', 'COLUMN', '{item.ColumnEName}'" + Environment.NewLine);
            }
            SbSql.Append(SbDS.ToString());
            return SbSql.ToString();
        }
        

        public IList<Schema> GetSchemaList(Worksheet sheet)
        {
            int initialRow = 2;
            IList<Schema> result = new List<Schema>();
            for(int i = initialRow; i <= sheet.Rows.Length; i++)
            {
                result.Add(new Schema() { 
                    ColumnEName = sheet[i, 1].Text,
                    ColumnCName = sheet[i, 2].Text,
                    DataType = sheet[i, 3].Text,
                    DataLength = sheet[i, 4].Value,
                    IsNullable = sheet[i, 5].Text,
                    IsPKey = sheet[i, 6].Text,
                    IsIdentity = sheet[i, 7].Text,
                    DefaultValue = sheet[i, 8].DisplayedText
                });
            }
            return result;
        }

        private List<Schema> GetDemoData()
        {
            return new List<Schema>()
            {
                new Schema()
                {
                    ColumnEName = "columnName1",
                    ColumnCName = "欄位名稱1",
                    DataType = "int",
                    IsNullable = "N",
                    IsPKey = "Y",
                    IsIdentity = "Y"
                },
                new Schema()
                {
                    ColumnEName = "columnName2",
                    ColumnCName = "欄位名稱2",
                    DataType = "nvarchar",
                    DataLength = "255",
                    IsNullable = "N",
                    IsPKey = "Y"
                },
                new Schema()
                {
                    ColumnEName = "columnName3",
                    ColumnCName = "欄位名稱3",
                    DataType = "nvarchar",
                    DataLength = "10",
                    DefaultValue = "''文字'"
                },
                new Schema()
                {
                    ColumnEName = "columnName4",
                    ColumnCName = "欄位名稱4",
                    DataType = "decimal",
                    DataLength = "7,0"
                },
                new Schema()
                {
                    ColumnEName = "columnName5",
                    ColumnCName = "欄位名稱5",
                    DataType = "datetime2",
                    DataLength = "0",
                    IsNullable = "N",
                    DefaultValue = "GETDATE()"
                },
            };
        }
    }
}