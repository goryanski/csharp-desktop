using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        void Create(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
