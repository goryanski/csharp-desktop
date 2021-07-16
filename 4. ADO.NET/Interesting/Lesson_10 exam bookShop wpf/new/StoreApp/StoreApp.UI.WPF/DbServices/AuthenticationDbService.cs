using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.BLL.Services;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.DbServices
{
    public class AuthenticationDbService
    {
        ServicesStorage services = ServicesStorage.Instance;

        public void CreateUser(SellerDTO seller)
        {
            services.SellersService.CreateSeller(seller);
        }

        internal bool UserExist(SellerDTO seller)
        {          
            SellerDTO srchSeller = services.SellersService.GetSellerByLogin(seller.Login);
            return (srchSeller is null) ? false : true;
        }

        internal bool IsPasswordCorrect(SellerDTO seller)
        {
            SellerDTO srchSeller = services.SellersService.GetSellerByLogin(seller.Login);
            return (srchSeller.Password == seller.Password) ? true : false;
        }
    }
}
