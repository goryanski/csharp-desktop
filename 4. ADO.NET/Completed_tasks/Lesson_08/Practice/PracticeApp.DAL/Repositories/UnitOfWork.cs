using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.DAL.Interfaces;

namespace PracticeApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection db;
        private OrdersRepository _productsRepos;
        private UsersRepository _categoriesRepos;

        public OrdersRepository OrdersRepository =>
            _productsRepos ?? (_productsRepos = new OrdersRepository(db));

        public UsersRepository UsersRepository
            => _categoriesRepos ?? (_categoriesRepos = new UsersRepository(db));
      

        public UnitOfWork(string connectionString)
        {
            db = new SqlConnection(connectionString);
            db.Open();
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
