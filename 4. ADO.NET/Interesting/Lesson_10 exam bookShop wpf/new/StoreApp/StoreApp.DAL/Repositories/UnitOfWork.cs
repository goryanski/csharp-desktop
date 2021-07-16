using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Entities.PeopleInfo;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories.ExtraTables;
using StoreApp.DAL.Repositories.PeopleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private StoreContext db;

        private SellersRepository _sellersRepos;
        public SellersRepository SellersRepository =>
           _sellersRepos ?? (_sellersRepos = new SellersRepository(db));


        private AuthorsRepository _authorsRepos;
        public AuthorsRepository AuthorsRepository =>
           _authorsRepos ?? (_authorsRepos = new AuthorsRepository(db));


        private CustomersRepository _customersRepos;
        public CustomersRepository CustomersRepository =>
           _customersRepos ?? (_customersRepos = new CustomersRepository(db));


        private BooksRepository _booksRepos;
        public BooksRepository BooksRepository =>
           _booksRepos ?? (_booksRepos = new BooksRepository(db));


        private PublishingOfficesRepository _publishRepos;
        public PublishingOfficesRepository PublishingOfficesRepository =>
           _publishRepos ?? (_publishRepos = new PublishingOfficesRepository(db));


        private SoldBooksRepository _soldBookhRepos;
        public SoldBooksRepository SoldBooksRepository =>
           _soldBookhRepos ?? (_soldBookhRepos = new SoldBooksRepository(db));


        private SetAsideBooksRepository _setAsideBooksRepos;
        public SetAsideBooksRepository SetAsideBooksRepository =>
           _setAsideBooksRepos ?? (_setAsideBooksRepos = new SetAsideBooksRepository(db));


        private WroteOffBooksRepository _wroteOffBooksRepos;
        public WroteOffBooksRepository WroteOffBooksRepository =>
           _wroteOffBooksRepos ?? (_wroteOffBooksRepos = new WroteOffBooksRepository(db));




        public UnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
            //DbInit();
        }

        private void DbInit()
        {
            #region sellers, customers
            Seller seller1 = new Seller
            {
                Login = "nina",
                Password = "1111"
            };
            Seller seller2 = new Seller
            {
                Login = "rita",
                Password = "1111"
            };
            db.Sellers.Add(seller1);
            db.Sellers.Add(seller2);


            Customer customer1 = new Customer
            {
                FullName = "Ansimova Elizaveta Andreevna"
            };
            Customer customer2 = new Customer
            {
                FullName = "Belyaev Matvey Artyomovich"
            };
            Customer customer3 = new Customer
            {
                FullName = "Gorbushin Vitaly Valerievich"
            };
            db.Customers.Add(customer1);
            db.Customers.Add(customer2);
            db.Customers.Add(customer3);

            #endregion

            #region offices, authors, books
            PublishingOffice office1 = new PublishingOffice
            {
                Name = "Roca"
            };
            PublishingOffice office2 = new PublishingOffice
            {
                Name = "SeaVio"
            };
            PublishingOffice office3 = new PublishingOffice
            {
                Name = "Nuala Dou"
            };
            db.PublishingOffices.Add(office1);
            db.PublishingOffices.Add(office2);
            db.PublishingOffices.Add(office3);

            db.SaveChanges();
        
            Author author1 = new Author
            {
                FullName = "Grinenko Alexey Alekseevich"
            };
            Author author2 = new Author
            {
                FullName = "Gruntal Mark Albertovich"
            };
            Author author3 = new Author
            {
                FullName = "Gursky Georgy Valentinovich"
            };
            Author author4 = new Author
            {
                FullName = "Dzhemgirov Ochir Sandjievich"
            };
            Author author5 = new Author
            {
                FullName = "Dunaev Yaroslav Alexandrovich"
            };
            Author author6 = new Author
            {
                FullName = "Lobastova Ekaterina Olegovna"
            };
            Author author7 = new Author
            {
                FullName = "Luzhetskaya Anastasia Viktorovna"
            };

            Book book1 = new Book
            {
                Name = "Sky",
                Discount = 0,
                Genre = "Nature",
                IsExist = true,
                IsSequel = false,
                Pages = 440,
                PrimeCost = 100,
                Price = 300,
                PublishingOfficeId = 1,
                PublishYear = 2010,
                AmountInStorage = 10,
                Authors = new List<Author> { author1, author2 }            
            };
            Book book2 = new Book
            {
                Name = "Bronze Key",
                Discount = 0,
                Genre = "Psychology",
                IsExist = true,
                IsSequel = false,
                Pages = 520,
                PrimeCost = 110,
                Price = 370,
                PublishingOfficeId = 2,
                PublishYear = 2016,
                AmountInStorage = 10,
                Authors = new List<Author> { author3, author5 }
            };
            Book book3 = new Book
            {
                Name = "Thieves of dreams",
                Discount = 0,
                Genre = "Drama",
                IsExist = true,
                IsSequel = false,
                Pages = 620,
                PrimeCost = 90,
                Price = 310,
                PublishingOfficeId = 3,
                PublishYear = 1993,
                AmountInStorage = 30,
                Authors = new List<Author> { author4 }
            };
            Book book4 = new Book
            {
                Name = "Red laugh",
                Discount = 0,
                Genre = "Horror",
                IsExist = true,
                IsSequel = false,
                Pages = 670,
                PrimeCost = 200,
                Price = 310,
                PublishingOfficeId = 3,
                PublishYear = 2021,
                AmountInStorage = 30,
                Authors = new List<Author> { author5 }
            };
            Book book5 = new Book
            {
                Name = "Child of sun",
                Discount = 0,
                Genre = "Science",
                IsExist = true,
                IsSequel = false,
                Pages = 470,
                PrimeCost = 180,
                Price = 510,
                PublishingOfficeId = 2,
                PublishYear = 1998,
                AmountInStorage = 1,
                Authors = new List<Author> { author2 }
            };
            Book book6 = new Book
            {
                Name = "In the morning",
                Discount = 0,
                Genre = "Philosofy",
                IsExist = true,
                IsSequel = true,
                Pages = 470,
                PrimeCost = 180,
                Price = 590,
                PublishingOfficeId = 1,
                PublishYear = 2019,
                AmountInStorage = 4,
                Authors = new List<Author> { author2 }
            };
            Book book7 = new Book
            {
                Name = "Ice",
                Discount = 0,
                Genre = "Animals",
                IsExist = true,
                IsSequel = false,
                Pages = 470,
                PrimeCost = 180,
                Price = 310,
                PublishingOfficeId = 1,
                PublishYear = 2020,
                AmountInStorage = 12,
                Authors = new List<Author> { author6 }
            };
            Book book8 = new Book
            {
                Name = "Golg knife",
                Discount = 0,
                Genre = "Thriller",
                IsExist = true,
                IsSequel = false,
                Pages = 670,
                PrimeCost = 180,
                Price = 610,
                PublishingOfficeId = 3,
                PublishYear = 2017,
                AmountInStorage = 12,
                Authors = new List<Author> { author7 }
            };

            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);
            db.Books.Add(book4);
            db.Books.Add(book5);
            db.Books.Add(book6);
            db.Books.Add(book7);
            db.Books.Add(book8);

            db.SaveChanges();
            #endregion

            #region soldBooks
            SoldBook sBook1 = new SoldBook
            {
                BookId = book1.Id,
                SoldDate = DateTime.Now.AddDays(-2)
            };
            SoldBook sBook2 = new SoldBook
            {
                BookId = book2.Id,
                SoldDate = DateTime.Now.AddDays(-5)
            };
            SoldBook sBook3 = new SoldBook
            {
                BookId = book3.Id,
                SoldDate = DateTime.Now
            };
            SoldBook sBook4 = new SoldBook
            {
                BookId = book4.Id,
                SoldDate = DateTime.Now.AddDays(-15)
            };
            SoldBook sBook5 = new SoldBook
            {
                BookId = book5.Id,
                SoldDate = DateTime.Now.AddDays(-22)
            };
            SoldBook sBook6 = new SoldBook
            {
                BookId = book2.Id,
                SoldDate = DateTime.Now.AddDays(-45)
            };
            SoldBook sBook7 = new SoldBook
            {
                BookId = book7.Id,
                SoldDate = DateTime.Now.AddDays(-90)
            };
            SoldBook sBook8 = new SoldBook
            {
                BookId = book8.Id,
                SoldDate = DateTime.Now.AddDays(-3)
            };
            SoldBook sBook9 = new SoldBook
            {
                BookId = book7.Id,
                SoldDate = DateTime.Now
            };
            SoldBook sBook10 = new SoldBook
            {
                BookId = book2.Id,
                SoldDate = DateTime.Now.AddDays(-90)
            };
            SoldBook sBook11 = new SoldBook
            {
                BookId = book7.Id,
                SoldDate = DateTime.Now.AddDays(-90)
            };
            SoldBook sBook12 = new SoldBook
            {
                BookId = book8.Id,
                SoldDate = DateTime.Now.AddDays(-90)
            };

            db.SoldBooks.Add(sBook1);
            db.SoldBooks.Add(sBook2);
            db.SoldBooks.Add(sBook3);
            db.SoldBooks.Add(sBook4);
            db.SoldBooks.Add(sBook5);
            db.SoldBooks.Add(sBook6);
            db.SoldBooks.Add(sBook7);
            db.SoldBooks.Add(sBook8);
            db.SoldBooks.Add(sBook9);
            db.SoldBooks.Add(sBook10);
            db.SoldBooks.Add(sBook11);
            db.SoldBooks.Add(sBook12);


            db.SaveChanges();

            #endregion
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
