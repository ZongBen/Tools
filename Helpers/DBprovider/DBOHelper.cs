using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Reflection;
using SharedHelper.Interface;

namespace DBproviderUtility
{
    public class DBOHelper
    {
        public object CreateProvider(string AssemblyName, string ProviderName)
        {
            return Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}");
        }

        public object CreateProvider(string AssemblyName, string ProviderName, out IDBTransaction DBTrans)
        {
            DBTrans = (IDBTransaction)Assembly.Load("SqlHelper").CreateInstance("BenLai.SqlUtility.DBTransaction");
            return Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { DBTrans }, null, null);
        }
        
        public IDBOperator ExecuteOperator(string AssemblyName, string ProviderName)
        {
            return (IDBOperator)Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}");
        }
        
    }
}
