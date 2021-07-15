using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Practice.Models;

namespace Practice
{
    class Library
    {
        BookStorage booksStorage;
        readonly Logger logger;

        public Library()
        {
            booksStorage = BookStorage.Instance;
            logger = LogManager.GetCurrentClassLogger();
        }


        public void AddBook()
        {
            Book book = FillBook();
            var result = ObjectValidator.Validate(book);
            if (!result.validated)
            {
                foreach (var item in result.errors)
                {
                    logger.Warn(item);
                }

                logger.Error("Book not added.");
                Console.WriteLine("Try again...");
            }
            else
            {
                booksStorage.Books.Add(book);
                Console.WriteLine("Book was added.");
            }
        }

        public void DeleteBook()
        {
            booksStorage.Books.RemoveAt(SelectBook() - 1);
            Console.WriteLine("Book was deleted.");
        }

        public void EditBook()
        {
            int select = SelectBook() - 1;
            Book book = FillBook();
            var result = ObjectValidator.Validate(book);
            if (!result.validated)
            {
                foreach (var item in result.errors)
                {
                    logger.Warn(item);
                }

                logger.Error("Book not edited.");
                Console.WriteLine("Try again...");
            }
            else
            {
                booksStorage.Books[select] = book;
                Console.WriteLine("Book was edited.");
            }
        }

        public void ShowBooks()
        {
            if (booksStorage.Books.Count > 0)
            {
                Console.WriteLine("\nList of all books:");
                int count = 0;
                booksStorage.Books.ForEach((book) =>
                {
                    Console.WriteLine($"[{++count}] {book}");
                });
            }
            else
            {
                Console.WriteLine("Library hasn't any books");
            }
        }
        Book FillBook()
        {
            Console.WriteLine("\nEnter info:");

            Console.Write("Book name: ");
            string name = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Book price: ");
            decimal price;
            decimal.TryParse(Console.ReadLine(), out price);
            Console.Write("Year of book writing: ");
            int year;
            int.TryParse(Console.ReadLine(), out year);

            return new Book { BookName = name, Author = author, Price = price, WritingYear = year };
        }
        int SelectBook()
        {
            ShowBooks();
            Console.Write("\nChoose book number: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > booksStorage.Books.Count)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }
            return select;
        }
    }
}
