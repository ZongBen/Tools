using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface IModelService
    {
        List<TableColumns> GetCols(string TableName, string ConnectStr);
        void AutoCode(List<TableColumns> model, string ModelName, string FolderPath);
    }
}
