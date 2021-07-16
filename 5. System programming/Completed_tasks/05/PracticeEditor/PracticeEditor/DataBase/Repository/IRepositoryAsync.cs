using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeEditor.DataBase.Entities;

namespace PracticeEditor.DataBase.Repository
{
    public interface IRepositoryAsync<T> 
     where T : BaseEntity
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Func<T, bool> predicate);
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(int id);
    }
}
