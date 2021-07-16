using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;

namespace StoreApp.DAL.Repositories
{
    public class BooksRepository : BaseRepository<Book, int>
    {
        public BooksRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(Book entity)
        {
            var updatedEntity = Get(entity.Id);
            updatedEntity.Name = entity.Name;
            updatedEntity.Pages = entity.Pages;
            updatedEntity.Genre = entity.Genre;
            updatedEntity.PrimeCost = entity.PrimeCost;
            updatedEntity.Price = entity.Price;
            updatedEntity.IsSequel = entity.IsSequel;
            updatedEntity.Discount = entity.Discount;
            updatedEntity.IsExist = entity.IsExist;
            updatedEntity.PublishYear = entity.PublishYear;
            updatedEntity.Authors = entity.Authors;
            updatedEntity.PublishingOfficeId = entity.PublishingOfficeId;
            updatedEntity.AmountInStorage = entity.AmountInStorage;
        }

        public void SetDiscount(int id, int discount)
        {
            var book = Get(id);
            book.Discount = discount;
        }

        public List<Book> GetAllBooksWithAuthors()
        {
           return db.Books.Include(b => b.Authors).ToList();
        }

        public void DecreaseCountBooksInStock(int id)
        {
            var book = Get(id);
            book.AmountInStorage--;
        }

        public override void Delete(int id)
        {
            var book = Get(id);
            book.IsExist = false;
        }

        public Book GetFullBookInfo(int id)
        {
            return db.Books.Include(b => b.Authors).Include(b => b.PublishingOffice)
                .Where(b => b.Id == id).First();
        }
    }
}
