using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models.Database.Entities;
using System.Linq;

namespace WpfApp1.Models.Database.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> 
        where T : BaseEntity
    {
        protected DatabaseContext db;
        private DbSet<T> Table => db.Set<T>();

        public BaseRepository(DatabaseContext context)
        {
            db = context;
        }
        public virtual void Create(T entity)
        {
            Table.Add(entity);
        }

        public virtual T Get(int id)
        {
            return Table.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual List<T> GetAll(Func<T, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public virtual void Remove(int id)
        {
            var entity = Get(id);
            Table.Remove(entity);
        }

        public abstract void Update(T entity);

    }
}
