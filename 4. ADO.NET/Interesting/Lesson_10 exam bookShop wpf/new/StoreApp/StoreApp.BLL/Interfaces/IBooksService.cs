using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;

namespace StoreApp.BLL.Interfaces
{
    public interface IBooksService
    {
        void CreateBook(BookDTO book);
        BookDTO GetBookById(int id);
    }
}
