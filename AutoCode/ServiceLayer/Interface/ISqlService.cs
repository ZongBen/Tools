using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametersLayer;

namespace ServiceLayer.Interface
{
    public interface ISqlService
    {
        List<string> GetCols(string TableName, string ConnectStr);
        CodeSqlResultModel AutoCodeInsert(string TableName, List<string> ColList);
        CodeSqlResultModel AutoCodeUpdate(string TableName, List<string> ColList);
    }
}
