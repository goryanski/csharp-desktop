using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models.Database.Repository
{
    public class UnitOfWork : IDisposable
    {
        static UnitOfWork _instance;

        DatabaseContext context;
        ProductsRepository productsRepository;
        CategoriesRepository categoriesRepository;

        public ProductsRepository ProductsRepository 
            => productsRepository ?? (productsRepository = new ProductsRepository(context));
        public CategoriesRepository CategoriesRepository
            => categoriesRepository ?? (categoriesRepository = new CategoriesRepository(context));
        public static UnitOfWork Instance => _instance ?? (_instance = new UnitOfWork());


        private UnitOfWork() 
        {
            context = new DatabaseContext();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
