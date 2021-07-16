using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeEditor.DataBase.Entities;

namespace PracticeEditor.DataBase
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            context.Users.Add(new User { FullName = "User 1", Age = 24 });
            context.Users.Add(new User { FullName = "User 2", Age = 22 });
            context.Users.Add(new User { FullName = "User 3", Age = 24 });
            context.Users.Add(new User { FullName = "User 4", Age = 21 });
            context.Users.Add(new User { FullName = "User 5", Age = 27 });

            context.SaveChanges();
        }
    }
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        static DatabaseContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DatabaseContext() : base("defaultConnection") // connection string in App.config
        {                   
        }
    }
}
