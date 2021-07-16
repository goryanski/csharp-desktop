using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeEditor.DataBase.Entities;

namespace PracticeEditor.DataBase.Repository
{
    public class UsersRepository : BaseRepository<User>
    {
        public override async Task Update(User entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.FullName = entity.FullName;
            srchEntity.Age = entity.Age;

            db.Entry(srchEntity).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
