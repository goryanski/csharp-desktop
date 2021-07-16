using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using StoreApp.BLL.Comparers;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.UI.WPF.Extensions;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.DbServices
{
    public class MainDbService
    {
        ServicesStorage services = ServicesStorage.Instance;

        internal ObservableCollection<BookDTO> GeTNewestBooks()
        {
            var books = services.BooksService.GetAllBooks()
                .Where(b => b.PublishYear == DateTime.Now.Year &&
                b.IsExist == true).ToList();

            ObservableCollection<BookDTO> observableBooks = new ObservableCollection<BookDTO>();
            observableBooks.AddRange(books);

            return observableBooks;
        }

        internal ObservableCollection<BookDTO> GeTMostPopularBooks()
        {
            var books = services.SoldBooksService.GeTMostPopularBooks()
                .Where(b => b.IsExist == true);
            
            ObservableCollection<BookDTO> observableBooks = new ObservableCollection<BookDTO>();
            observableBooks.AddRange(books);

            return observableBooks;
        }

        public string GeTMostPopularAuthors()
        {
            var authors = services.SoldBooksService.GetAuthorsMostPopularBooks();

            string authorsStr = string.Empty;
            foreach (var author in authors)
            {
                authorsStr += $"{author}\n";
            }

            return authorsStr;
        }

        public string GeTMostPopularBooks(int duration)
        {
            var books = services.SoldBooksService.GeTMostPopularBooks();

            string genresStr = string.Empty;
            foreach (var book in books)
            {
                var soldBook = services.SoldBooksService.GetBookById(book.Id);
                if (soldBook != null && DateTime.Now.AddDays(-duration) <= soldBook.SoldDate)
                {
                    genresStr += $"{book.Genre}\n";
                }                
            }
            return genresStr;
        }

        public void SellBook(int id)
        {
            SoldBookDTO soldBook = new SoldBookDTO
            {
                BookId = id,
                SoldDate = DateTime.Now
            };

            services.SoldBooksService.CreateBook(soldBook);
            services.BooksService.DecreaseCountBooksInStock(id);
        }

        internal List<BookDTO> GetExistsBooks()
        {
            return services.BooksService.GetAllBooksWithAuthors()
                .Where(b => b.IsExist == true).ToList();
        }

        internal ObservableCollection<BookDTO> FindSearchMatches(string text)
        {         
            // находим совпадения по имени и жанрам 
            var books = services.BooksService.GetAllBooks()
                .Where(b => b.Name.ToUpper().Contains(text.ToUpper()) ||
                b.Genre.ToUpper().Contains(text.ToUpper())).ToList();


            // находим совпадения по авторам
            var booksWithAuthors = services.BooksService.GetAllBooksWithAuthors();
            List<BookDTO> booksOfAuthors = new List<BookDTO>();
            
            foreach (var book in booksWithAuthors)
            {
                foreach (var author in book.Authors)
                {
                    if (author.FullName.ToUpper().Contains(text.ToUpper()))
                    {
                        booksOfAuthors.Add(book);
                    }
                }
            }


            // объединяем совпадения 
            List<BookDTO> unionBooks = new List<BookDTO>();
            unionBooks.AddRange(books);
            unionBooks.AddRange(booksOfAuthors);

            // что бы не повторялись
            var res = unionBooks.Distinct(new BookComparer()).ToList();

            ObservableCollection<BookDTO> observableBooks = new ObservableCollection<BookDTO>();
            observableBooks.AddRange(res);

            return observableBooks;
        }

        internal void RemoveBook(int id) => services.BooksService.RemoveBook(id);
    }
}
