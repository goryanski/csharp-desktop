using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice
{
    class BookStorage
    {
        private static BookStorage instance;
        public static BookStorage Instance { get => instance ?? (instance = new BookStorage()); }
        public List<Book> Books { get; set; }

        private BookStorage()
        {
            // по умолчанию будет 3 книги
            Books = new List<Book>
            {
                new Book { 
                    BookName = "Harry Potter", 
                    Author = "D.K. Roling", 
                    WritingYear = 2005, 
                    Price = 200
                },
                new Book { 
                    BookName = "War and peace", 
                    Author = "L. Tolstoy", 
                    WritingYear = 1865, 
                    Price = 100
                },
                new Book { 
                    BookName = "Bukvar", 
                    Author = "V. Petrov", 
                    WritingYear = 2000, 
                    Price = 50
                }             
            };
        }
    }
}
