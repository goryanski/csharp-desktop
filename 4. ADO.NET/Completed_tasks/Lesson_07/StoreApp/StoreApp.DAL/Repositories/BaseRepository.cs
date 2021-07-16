using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StoreApp.DAL.Repositories
{
    public abstract class BaseRepository<TValue, TKey> : IRepository<TValue, TKey>
        where TValue : BaseEntity<TKey>
        where TKey : struct
    {
        protected StoreContext db;
        DbSet<TValue> Table => db.Set<TValue>();
        public BaseRepository(StoreContext context)
        {
            db = context;
        }

        public virtual void Create(TValue entity)
        {
            Table.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            var entity = Get(id);
            Table.Remove(entity);
        }

        public virtual TValue Get(TKey id)
        {
            return Table.FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public virtual List<TValue> GetAll()
        {
            return Table.ToList();
        }

        public virtual List<TValue> GetAll(Func<TValue, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public abstract void Update(TValue entity);
    }
}
