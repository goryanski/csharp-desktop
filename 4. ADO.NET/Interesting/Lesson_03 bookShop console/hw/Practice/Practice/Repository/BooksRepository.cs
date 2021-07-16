using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Entities;

namespace Practice.Repository
{
    public class BooksRepository : IRepository<Book>
    {
        DataContext context;
        public BooksRepository(DataContext ctx)
        {
            context = ctx;
        }

        public void Create(Book entity)
        {
            Table().InsertOnSubmit(entity);
            context.SubmitChanges();
        }

        public void Delete(int id)
        {
            // вместо удаления изменяем значение поля IsDeleted
            var book = Get(id);
            book.IsDeleted = true;
            context.SubmitChanges();
        }

        public Book Get(int id)
        {
            return Table().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return Table().ToList();
        }

        public IEnumerable<Book> GetAll(Func<Book, bool> predicate)
        {
            return Table().Where(predicate).ToList();
        }

        public void Update(Book entity)
        {
            var book = Get(entity.Id);
            book.Name = entity.Name;
            book.Pages = entity.Pages;
            book.Price = entity.Price;
            book.PublishDate = entity.PublishDate;
            book.AuthorId = entity.AuthorId;
            book.ThemeId = entity.ThemeId;
            book.IsDeleted = entity.IsDeleted;

            context.SubmitChanges();
        }

        private Table<Book> Table() => context.GetTable<Book>();
    }
}
