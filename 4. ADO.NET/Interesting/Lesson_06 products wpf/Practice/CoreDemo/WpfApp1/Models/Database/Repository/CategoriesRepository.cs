using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models.Database.Models;

namespace WpfApp1.Models.Database.Repository
{
    public class CategoriesRepository : BaseRepository<Category>
    {
        public CategoriesRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
