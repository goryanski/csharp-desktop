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
        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }
        
        public virtual void Create(T entity)
        {
            Table().Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            Table().Remove(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return Table().FirstOrDefault(entity => entity.Id == id);
        }


        public virtual IEnumerable<T> GetAll()
        {
            return Table().ToList();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return Table().Where(predicate).ToList();
        }


        public abstract void Update(T entity);

        private DbSet<T> Table() => context.Set<T>();
    }
}
