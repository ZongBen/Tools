using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using ParametersLayer;
using System.IO;

namespace ServiceLayer
{
    public class ModelService : IModelService
    {
        private readonly IDBProvider _Provider;
        private readonly ICommonService _commonService;
        public ModelService()
        {
            _Provider = new DBProvider();
            _commonService = new CommonService();
        }
        public List<TableColumns> GetCols(string TableName, string ConnectStr)
        {
            IList<TableColumns> tableColumns = _Provider.GetTableColumns(TableName, ConnectStr);
            return tableColumns.ToList();
        }

        public void AutoCode(List<TableColumns> model,string ModelName, string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            FolderPath += $"\\{ModelName}.cs";
            StreamWriter sw = File.CreateText(FolderPath);
            sw.Write(_commonService.CodeClass(ModelName, model));
            sw.Flush();
            sw.Close();
        }
    }
}
