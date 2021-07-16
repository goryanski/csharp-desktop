using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.BLL.Interfaces
{

    public interface ISellersService
    {
        void CreateSeller(SellerDTO seller);
        SellerDTO GetSellerById(int id);
    }
}
