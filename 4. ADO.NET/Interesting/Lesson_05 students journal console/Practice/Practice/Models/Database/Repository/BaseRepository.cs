using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public abstract class BaseRepository<T>
        : IRepository<T> where T : BaseEntity
    {
        protected DatabaseContext context;
        private DbSet<T> Table => context.Set<T>();

        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public virtual void Create(T entity)
        {
            Table.Add(entity);
            context.SaveChanges();
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
            context.SaveChanges();
        }

        public abstract void Update(T entity);
    }
}
