using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Entities;

namespace Practice.Repository
{
    public class PeopleRepository : IRepository<Person>
    {
        DataContext context;
        public PeopleRepository(DataContext ctx)
        {
            context = ctx;
        }
        public void Create(Person entity)
        {
            Table().InsertOnSubmit(entity);
            context.SubmitChanges();
        }

        public void Delete(int id)
        {
            var person = Get(id);
            Table().DeleteOnSubmit(person);
            context.SubmitChanges();
        }

        public Person Get(int id)
        {
            return Table().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return Table().ToList();
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> predicate)
        {
            return Table().Where(predicate).ToList();
        }

        public void Update(Person entity)
        {
            var person = Get(entity.Id);
            person.FirstName = entity.FirstName;
            person.LastName = entity.LastName;
            person.Birth = entity.Birth;
            person.AccountId = entity.AccountId;

            context.SubmitChanges();
        }

        private Table<Person> Table() => context.GetTable<Person>();
    }
}
