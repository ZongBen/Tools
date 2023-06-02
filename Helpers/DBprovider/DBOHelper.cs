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
            return Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { false }, null, null);
        }

        public object CreateProvider(string AssemblyName, string ProviderName, out IDBTransaction DBTrans)
        {
            var asm = Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { true }, null, null);
            DBTrans = (IDBTransaction)asm;
            return asm;
        }
        
        public IDBOperator ExecuteOperator(string AssemblyName, string ProviderName)
        {
            return (IDBOperator)Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { false }, null, null);
        }

        public IDBOperator ExecuteOperator(string AssemblyName, string ProviderName, out IDBTransaction DBTrans)
        {
            var asm = Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { true }, null, null);
            DBTrans = (IDBTransaction)asm;
            return (IDBOperator)asm;
        }
    }
}
