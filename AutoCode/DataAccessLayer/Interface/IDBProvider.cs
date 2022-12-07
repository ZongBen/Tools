using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametersLayer;

namespace DataAccessLayer.Interface
{
    public interface IDBProvider
    {
        IList<TableColumns> GetTableColumns(string TableName, string Constr);
    }
}
