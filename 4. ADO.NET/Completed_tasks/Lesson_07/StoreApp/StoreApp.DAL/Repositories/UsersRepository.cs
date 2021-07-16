using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StoreApp.DAL.Repositories
{
    public class UsersRepository : BaseRepository<User, int>
    {
        public UsersRepository(StoreContext context) : base(context)
        {
        }

        public override List<User> GetAll()
        {
            return db.Users.Include(u => u.Orders).ToList();
        }

        public override void Update(User entity)
        {
            var updatedEntity = Get(entity.Id);
            updatedEntity.IsBlocked = true;
        }
    }
}
