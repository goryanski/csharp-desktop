using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.DbServices
{
    public class BooksEditorDbService
    {
        ServicesStorage services = ServicesStorage.Instance;

        public BookDTO CreateBook(BookModelValidation book)
        {
            BookDTO bookDTO = FillBook(book);
            services.BooksService.CreateBook(bookDTO);
            return bookDTO;
        }

        internal BookDTO UpdateBook(BookModelValidation book)
        {
            BookDTO bookDTO = FillBook(book);
            bookDTO.Id = book.Id;
            services.BooksService.UpdateBook(bookDTO);            
            return bookDTO;
        }

        private BookDTO FillBook(BookModelValidation book)
        {
            PublishingOfficeDTO office = new PublishingOfficeDTO
            {
                Name = book.PublishingOffice
            };
            services.PublishingOfficesService.CreatePublishingOffice(office);

            PublishingOfficeDTO publishingOffice = services.PublishingOfficesService.GetAllOffices()
               .Where(o => o.Name == office.Name).FirstOrDefault();



            AuthorDTO authorDTO1 = new AuthorDTO
            {
                FullName = book.Author1
            };
            List<AuthorDTO> authors = new List<AuthorDTO> { authorDTO1 };

            if (book.Author2 != string.Empty)
            {
                AuthorDTO authorDTO2 = new AuthorDTO
                {
                    FullName = book.Author2
                };
                authors.Add(authorDTO2);
            }
            if (book.Author3 != string.Empty)
            {
                AuthorDTO authorDTO3 = new AuthorDTO
                {
                    FullName = book.Author3
                };
                authors.Add(authorDTO3);
            }
            if (book.Author4 != string.Empty)
            {
                AuthorDTO authorDTO4 = new AuthorDTO
                {
                    FullName = book.Author4
                };
                authors.Add(authorDTO4);
            }
            if (book.Author5 != string.Empty)
            {
                AuthorDTO authorDTO5 = new AuthorDTO
                {
                    FullName = book.Author5
                };
                authors.Add(authorDTO5);
            }


            BookDTO bookDTO = new BookDTO
            {
                Name = book.Name,
                Discount = int.Parse(book.Discount),
                Genre = book.Genre,
                IsExist = true,
                IsSequel = book.IsSequel,
                Pages = int.Parse(book.Pages),
                PrimeCost = book.PrimeCost,
                Price = book.Price,
                PublishingOfficeId = publishingOffice.Id,
                PublishYear = int.Parse(book.PublishYear),
                AmountInStorage = int.Parse(book.AmountInStorage),
                Authors = authors
            };

            return bookDTO;
        }

        internal BookDTO GetFullBookInfo(int id) => services.BooksService.GetFullBookInfo(id);
    }
}
