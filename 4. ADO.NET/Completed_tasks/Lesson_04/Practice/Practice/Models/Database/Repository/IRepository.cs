using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Models.Database.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        void Delete(int id);
        void Update(T entity);
        void Create(T entity);
    }
}
