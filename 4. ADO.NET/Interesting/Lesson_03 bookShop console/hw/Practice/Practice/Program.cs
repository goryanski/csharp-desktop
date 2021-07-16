using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.App;
using Practice.Entities;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            new Application().Start();
        }


        // Задание 2
        public interface IRepository<T>
        {
            T Get(int id);
            IEnumerable<T> GetAll();
            IEnumerable<T> GetAll(Func<T, bool> predicate);
            void Delete(int id);
            void Update(T entity);
            void Create(T entity);
        }


        public abstract class BaseEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }
        }


        public abstract class BaseRepository<T>
       : IRepository<T> where T : BaseEntity
        {
            protected DataContext context;
            public BaseRepository(DataContext context)
            {
                this.context = context;
            }
            public virtual Table<T> Table() => context.GetTable<T>();
            public virtual void Create(T entity)
            {
                Table().InsertOnSubmit(entity);
                context.SubmitChanges();
            }

            public virtual void Delete(int id)
            {
                var entity = Get(id);
                Table().DeleteOnSubmit(entity);
                context.SubmitChanges();
            }

            public virtual T Get(int id)
            {
                return Table().FirstOrDefault(entity => entity.Id == id);
            }

            public virtual IEnumerable<T> GetAll()
            {
                return Table().ToList();
            }

            public virtual IEnumerable<T> GetAll(Func<T, bool> predicate)
            {
                return Table().Where(predicate).ToList();
            }
            public abstract void Update(T entity);
        }



        [Table(Name = "Accounts")]
        public class Account : BaseEntity
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }
            [Column]
            public string Login { get; set; }
            [Column]
            public string Password { get; set; }
            [Column(Name = "regDate")]
            public DateTime RegistrationDate { get; set; }
        }

        public class AccountsRepository : BaseRepository<Account>
        {
            public AccountsRepository(DataContext ctx) : base(ctx) { }

            public override void Update(Account entity)
            {
                var account = Get(entity.Id);
                account.Login = entity.Login;
                account.Password = entity.Password;

                context.SubmitChanges();
            }
        }
    }
}
