using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.DAL.Entities.ExtraTables;

namespace StoreApp.BLL.Interfaces
{
    public interface ISoldBooksService
    {
        void CreateBook(SoldBookDTO book);
        SoldBookDTO GetBookById(int id);
    }
}
