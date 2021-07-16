using StoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Interfaces
{
    public interface IRepository<TValue, TKey> 
        where TValue : BaseEntity<TKey>
        where TKey : struct
    {
        TValue Get(TKey id);
        List<TValue> GetAll();
        List<TValue> GetAll(Func<TValue, bool> predicate);
        void Create(TValue entity);
        void Delete(TKey id);
        void Update(TValue entity);
    }
}
