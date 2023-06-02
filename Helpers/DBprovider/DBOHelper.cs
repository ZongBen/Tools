using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Reflection;

namespace DBproviderUtility
{
    public interface IDBTransaction
    {
        void Commit();
        void RollBack();
    }

    public class DBOHelper
    {
        public object CreateProvider(string AssemblyName, string ProviderName)
        {
            return Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}");
        }

        public object CreateProvider(string AssemblyName, string ProviderName, out IDBTransaction Trans)
        {
            Trans = (IDBTransaction)Assembly.Load("SqlHelper").CreateInstance("BenLai.SqlUtility.DBTransaction");
            return Assembly.Load(AssemblyName).CreateInstance($"{AssemblyName}.{ProviderName}", false, BindingFlags.Default, null, new object[] { Trans }, null, null);
        }
    }
}
