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
        void RollBack();
    }

    public interface IDBOperator
    {
        IDBModel<T> Get<T>(T Model) where T : class, new();
        //int SaveChange<T>(IDBModel<T> Model) where T : class, new();
    }

    public interface IDBModel<T>
    {
        T Model { get; }
    }
}
