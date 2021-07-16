using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Entities.PeopleInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.EF
{
    public class StoreContext : DbContext
    {
        private string connectionString = string.Empty;

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PublishingOffice> PublishingOffices { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }
        public DbSet<WroteOffBook> WroteOffBooks { get; set; }
        public DbSet<SetAsideBook> SetAsideBooks { get; set; }

        public StoreContext(string connectionString)
        {
            this.connectionString = connectionString;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

