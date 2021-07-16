using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.ExtraTables;

namespace StoreApp.BLL.Interfaces
{
    public interface ISetAsideBookService
    {
        void CreateSetAsideBook(SetAsideBookDTO book);
        SetAsideBookDTO GetSetAsideBookById(int id);
    }
}
