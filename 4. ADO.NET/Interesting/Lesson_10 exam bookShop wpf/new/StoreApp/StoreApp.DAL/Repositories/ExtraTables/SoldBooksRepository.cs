using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.DAL.Repositories.ExtraTables
{
    public class SoldBooksRepository : BaseRepository<SoldBook, int>
    {
        public SoldBooksRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(SoldBook entity)
        {
        }

        public List<Book> GeTMostPopularBooks()
        {
            return db.Books.FromSqlRaw("SELECT * FROM GetMostPopularBooks()").ToList();                   
        }

        public List<Author> GetAuthorsMostPopularBooks()
        {
            return db.Authors.FromSqlRaw("SELECT * FROM GetAuthorsMostPopularBooks()").ToList();
        }
    }
}
