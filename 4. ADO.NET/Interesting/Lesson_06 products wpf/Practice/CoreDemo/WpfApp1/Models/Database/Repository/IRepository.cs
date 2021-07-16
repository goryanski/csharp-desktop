using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models.Database.Entities;

namespace WpfApp1.Models.Database.Repository
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        void Create(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
