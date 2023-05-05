using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DBproviderUtility
{
    public class DBprovider
    {
        public SqlTransaction ExecuteTransaction()
        {
            return new SqlTransaction();
        }
    }

    public class SqlTransaction
    {
        private TransactionScope Scope { get; set; }
        internal SqlTransaction()
        {
            Scope = new TransactionScope();
        }
        public void Commit()
        {
            Scope.Complete();
            Scope.Dispose();
        }
        public void Rollback()
        {
            Scope.Dispose();
        }
    }
}
