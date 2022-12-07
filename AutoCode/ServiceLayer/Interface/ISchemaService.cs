using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface ISchemaService
    {
        Workbook LoadExcel(string FilePath);
        string CreateTable(Worksheet sheet);
        string ExportExcelTemplate(string Path);
        IList<Schema> GetSchemaList(Worksheet sheet);
        string AddCol(string TableName, IList<Schema> SchemaList);
    }
}
