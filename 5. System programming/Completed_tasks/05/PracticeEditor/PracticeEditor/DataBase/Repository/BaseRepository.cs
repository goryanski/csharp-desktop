using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeEditor.DataBase.Entities;

namespace PracticeEditor.DataBase.Repository
{
    public abstract class BaseRepository<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected DatabaseContext db;
        private DbSet<T> Table => db.Set<T>();

        public BaseRepository()
        {
            db = new DatabaseContext();
        }
        public virtual async Task Create(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
            await db.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Table.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<List<T>> GetAll(Func<T, bool> predicate)
        {
            return await Task.Run(() => Table.Where(predicate).ToList());
        }

        public async Task Remove(int id)
        {
            var entity = await Get(id);
            db.Entry(entity).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public abstract Task Update(T entity);
    }
}
