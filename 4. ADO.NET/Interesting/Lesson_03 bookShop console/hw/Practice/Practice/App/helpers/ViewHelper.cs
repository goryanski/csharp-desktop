using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Entities;
using Practice.Repository;

namespace Practice.App.helpers
{
    public class ViewHelper
    {      
        public List<Book> GetBooksList(string how)
        {
            BooksRepository booksRepository = new BooksRepository(new DbHelper().GetContext());
            // удаленные книги просто не будем показывать, тогда их нельзя будет выбрать и что-либо с ними сделать
            var books = booksRepository.GetAll().Where(b => b.IsDeleted == false);

            switch (how)
            {
                case "ByDefault":
                    return books.ToList();
                case "ByIncreasing":
                    return books.OrderBy(b => b.Price).ToList();
                case "ByDescending":
                    return books.OrderByDescending(b => b.Price).ToList();
            }
            return null;
        }

        public List<Book> ShowBooks(string how)
        {
            List<Book> books = GetBooksList(how);            

            if (books != null)
            {
                Console.WriteLine("\nList of all books:");
                int count = 0;
                books.ForEach((book) =>
                {
                    Console.WriteLine($"[{++count}] {book}");
                });
            }
            else
            {
                Console.WriteLine("Book shop hasn't any books");
            }

            return books;
        }

        public int GetIdSelectedBook()
        {
            List<Book> books = ShowBooks("ByDefault");
            if (books != null)
            {
                Console.Write("\nChoose book number: ");
                int select;
                int.TryParse(Console.ReadLine(), out select);

                while (select < 1 || select > books.Count)
                {
                    Console.Write("Wrong number, try again: ");
                    int.TryParse(Console.ReadLine(), out select);
                }
                return books[select - 1].Id;
            }
            return -1;
        }

        public void ShowSelectdBookFullInfo()
        {
            int id = GetIdSelectedBook();

            if (id != -1)
            {
                // будем находить по id не сразу с базы, а через метод GetBooksList() что бы не было возможности выбрать удаленные
                List<Book> books = GetBooksList("ByDefault");

                Console.WriteLine (
                    books.FirstOrDefault(b => b.Id == id).GetFullInfo()
                );
            }
        }
    }
}
