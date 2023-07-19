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
    /// <summary>
    /// 
    /// </summary>
    public class DBOHelper
    {
        /// <summary>
        /// 與繼承SqlHelper的類別建立新的執行個體。
        /// </summary>
        /// <param name="AssemblyName">組件名稱</param>
        /// <param name="NameSpace">命名空間</param>
        /// <param name="ProviderName">類別名稱</param>
        /// <returns>組件執行個體</returns>
        public object CreateProvider(string AssemblyName, string NameSpace, string ProviderName)
        {
            return Assembly.Load(AssemblyName).CreateInstance($"{NameSpace}.{ProviderName}", false, BindingFlags.Default, null, new object[] { false }, null, null);
        }
        /// <summary>
        /// 與繼承SqlHelper的類別建立新的執行個體，並啟動資料庫交易。
        /// </summary>
        /// <param name="AssemblyName">組件名稱</param>
        /// <param name="NameSpace">命名空間</param>
        /// <param name="ProviderName">類別名稱</param>
        /// <param name="DBTrans">資料庫交易執行個體</param>
        /// <returns>組件執行個體</returns>
        public object CreateProvider(string AssemblyName, string NameSpace, string ProviderName, out IDBTransaction DBTrans)
        {
            var asm = Assembly.Load(AssemblyName).CreateInstance($"{NameSpace}.{ProviderName}", false, BindingFlags.Default, null, new object[] { true }, null, null);
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
