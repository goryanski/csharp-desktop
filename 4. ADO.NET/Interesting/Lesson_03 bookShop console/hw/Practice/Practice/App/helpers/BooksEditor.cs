using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Entities;
using Practice.Repository;

namespace Practice.App.helpers
{
    public class BooksEditor
    {
        BooksRepository booksRepository = new BooksRepository(new DbHelper().GetContext());
        ViewHelper helper = new ViewHelper();
        Validator validator = new Validator();

        public Book FillBook()
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();
            Console.Write("Enter count pages: ");
            int pages = validator.SafelyInput(new int());
            Console.Write("Enter price: ");
            decimal price = validator.SafelyInput(new decimal());
            Console.Write("Enter publish date: ");
            DateTime date = validator.SafelyInput(new DateTime());
            Console.Write("Enter author id: ");
            int authorId = validator.SafelyInput(new int());
            Console.Write("Enter theme id: ");
            int themeId = validator.SafelyInput(new int());


            Book book = new Book
            {
                Name = name,
                Pages = pages,
                Price = price,
                PublishDate = date,
                AuthorId = authorId,
                ThemeId = themeId,
                IsDeleted = false
            };

            return book;
        }

        public void AddBook()
        {
            Book book = FillBook();
            booksRepository.Create(book);
            Console.WriteLine("Success");
        }

        public void EditBook()
        {
            int id = helper.GetIdSelectedBook();
            Book book = FillBook();
            book.Id = id; // id книги котор обновляем
            booksRepository.Update(book);
            Console.WriteLine("Success");
        }

        public void DeleteBook()
        {           
            int id = helper.GetIdSelectedBook();
            booksRepository.Delete(id);
            Console.WriteLine("Success");
        }
    }
}
