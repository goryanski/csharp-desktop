using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.ExtraTables;

namespace StoreApp.BLL.Interfaces
{
    public interface IWroteOffBookService
    {
        void CreateWroteOffBook(WroteOffBookDTO book);
        WroteOffBookDTO GetWroteOffBookById(int id);
    }
}
