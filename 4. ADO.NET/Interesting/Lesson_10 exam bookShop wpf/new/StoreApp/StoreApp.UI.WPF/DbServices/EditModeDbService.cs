using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.DbServices
{
    public class EditModeDbService
    {
        ServicesStorage services = ServicesStorage.Instance;

        internal void SetDiscount(int id, int discount)
        {
            services.BooksService.SetDiscount(id, discount);
        }

        internal void WriteOffBook(int id)
        {
            ;
            WroteOffBookDTO book = new WroteOffBookDTO
            {
                BookId = id,
                Date = DateTime.Now
            };

            services.WroteOffBookService.CreateWroteOffBook(book);
            services.BooksService.DecreaseCountBooksInStock(id);
        }

        internal List<CustomerDTO> GetCustomers()
        {
            return services.CustomersService.GetAllCustomers()
                .OrderBy(c => c.FullName).ToList(); // для удобного поиска
        }

        internal void SetBookAside(int bookId, int customerId)
        {
            SetAsideBookDTO book = new SetAsideBookDTO
            {
                BookId = bookId,
                CustomerId = customerId,
                Date = DateTime.Now
            };

            services.SetAsideBookService.CreateSetAsideBook(book);
            services.BooksService.DecreaseCountBooksInStock(bookId);
        }
    }
}
