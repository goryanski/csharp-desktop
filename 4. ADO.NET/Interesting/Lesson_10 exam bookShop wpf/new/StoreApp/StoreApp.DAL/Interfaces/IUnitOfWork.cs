using StoreApp.DAL.Entities;
using StoreApp.DAL.Repositories;
using StoreApp.DAL.Repositories.ExtraTables;
using StoreApp.DAL.Repositories.PeopleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        SellersRepository SellersRepository { get; }
        AuthorsRepository AuthorsRepository { get; }
        CustomersRepository CustomersRepository { get; }
        BooksRepository BooksRepository { get; }
        PublishingOfficesRepository PublishingOfficesRepository { get; }
        SoldBooksRepository SoldBooksRepository { get; }

        SetAsideBooksRepository SetAsideBooksRepository { get; }
        WroteOffBooksRepository WroteOffBooksRepository { get; }

        void Save();
    }
}
