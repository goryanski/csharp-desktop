using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models.Database.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Models.Database.Repository
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Update(Product entity)
        {
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return db.Products.Where(prod => prod.CategoryId == id).ToList();
        }
    }
}
