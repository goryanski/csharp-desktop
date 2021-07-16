using StoreApp.DAL.Entities;
using StoreApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        OrdersRepository OrdersRepository { get; }
        UsersRepository UsersRepository { get; }

        void Save();
    }
}
