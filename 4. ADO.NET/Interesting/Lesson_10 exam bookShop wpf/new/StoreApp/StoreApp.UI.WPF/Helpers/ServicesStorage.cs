using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.Services;
using StoreApp.BLL.Services.ExtraTables;
using StoreApp.BLL.Services.PeopleInfo;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories;

namespace StoreApp.UI.WPF.Helpers
{
    public class ServicesStorage
    {
        IUnitOfWork uow;
        public SellersService SellersService { get; set; }
        public CustomersService CustomersService { get; set; }
        public AuthorsService AuthorsService { get; set; }
        public BooksService BooksService { get; set; }
        public PublishingOfficesService PublishingOfficesService { get; set; }
        public SoldBooksService SoldBooksService { get; set; }
        public WroteOffBookService WroteOffBookService { get; set; }
        public SetAsideBookService SetAsideBookService { get; set; }




        static ServicesStorage _instance;
        public static ServicesStorage Instance => _instance ?? (_instance = new ServicesStorage());
        private ServicesStorage()
        {          
            uow = new UnitOfWork(@"Data Source=DESKTOP-RG3HTFI;Initial Catalog=BookShopExamDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SellersService = new SellersService(uow);
            CustomersService = new CustomersService(uow);
            AuthorsService = new AuthorsService(uow);
            BooksService = new BooksService(uow);
            PublishingOfficesService = new PublishingOfficesService(uow);
            SoldBooksService = new SoldBooksService(uow);
            WroteOffBookService = new WroteOffBookService(uow);
            SetAsideBookService = new SetAsideBookService(uow);
        }
    }
}
