using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.DAL.Entities;

namespace PracticeApp.DAL.Interfaces
{
    public interface IRepository<TValue, TKey>
        where TValue : BaseEntity<TKey>
        where TKey : struct
    {
        TValue Get(TKey id);
        List<TValue> GetAll();
        void Create(TValue entity);
        void Delete(TKey id);
    }
}
