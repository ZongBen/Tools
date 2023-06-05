using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelper.Interface
{
    public interface IDBTransaction
    {
        void Commit();
        void Rollback();
    }

    public interface IDBOperator
    {
        IDBModel<T> GetByKey<T>(T Model) where T : class, new();
        int Insert<T>(T Model) where T : class, new();
        int Update<T>(IDBModel<T> dbModel, Action<T> action = null) where T : class, new();
        int Delete<T>(T Model) where T : class, new();
    }

    public interface IDBModel<T>
    {
        T Model { get; }
    }
}
