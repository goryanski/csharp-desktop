using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Entities;

namespace Practice.Repository
{
    public class AccountsRepository : IRepository<Account>
    {
        DataContext context;
        public AccountsRepository(DataContext ctx)
        {
            context = ctx;
        }
        public void Create(Account entity)
        {
            Table().InsertOnSubmit(entity);
            context.SubmitChanges();
        }

        public void Delete(int id)
        {
            var acc = Get(id);
            Table().DeleteOnSubmit(acc);
            context.SubmitChanges();
        }

        public Account Get(int id)
        {
            return Table().FirstOrDefault(acc => acc.Id == id);
        }

        public Account Get(Func<Account, bool> predicate)
        {
            return Table().FirstOrDefault(predicate);
        }

        public IEnumerable<Account> GetAll()
        {
            return Table().ToList();
        }

        public IEnumerable<Account> GetAll(Func<Account, bool> predicate)
        {
            return Table().Where(predicate).ToList();
        }

        public void Update(Account entity)
        {
            var account = Get(entity.Id);
            account.Login = entity.Login;
            account.Password = entity.Password;

            context.SubmitChanges();
        }

        private Table<Account> Table() => context.GetTable<Account>();
    }
}
