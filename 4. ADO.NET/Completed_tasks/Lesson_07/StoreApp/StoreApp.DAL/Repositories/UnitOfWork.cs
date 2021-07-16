using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreContext db;
        private OrdersRepository _productsRepos;
        private UsersRepository _categoriesRepos;

        public OrdersRepository OrdersRepository => 
            _productsRepos ?? (_productsRepos = new OrdersRepository(db));

        public UsersRepository UsersRepository
            => _categoriesRepos ?? (_categoriesRepos = new UsersRepository(db));

        public UnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
