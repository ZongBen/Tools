using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Reflection;
using BenLai.SharedHelper.Interface;

namespace BenLai.DBproviderUtility
{
    public class DBOHelper
    {
        public object CreateProvider(string AssemblyName, string NameSapce, string ProviderName)
        {
            return Assembly.Load(AssemblyName).CreateInstance($"{NameSapce}.{ProviderName}", false, BindingFlags.Default, null, new object[] { false }, null, null);
        }

        public object CreateProvider(string AssemblyName, string NameSapce, string ProviderName, out IDBTransaction DBTrans)
        {
            var asm = Assembly.Load(AssemblyName).CreateInstance($"{NameSapce}.{ProviderName}", false, BindingFlags.Default, null, new object[] { true }, null, null);
            DBTrans = (IDBTransaction)asm;
            return asm;
        }
        
        public IDBOperator ExecuteOperator(object InstancedProvider)
        {
            return (IDBOperator)InstancedProvider;
        }

        public IDBOperator<T> ExecuteOperator<T>(object InstancedProvider) where T : class, new()
        {
            return (IDBOperator<T>)InstancedProvider;
        }
    }
}
