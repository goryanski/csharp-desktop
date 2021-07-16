using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.EF
{
    public class StoreContext : DbContext
    {
        private string connectionString = string.Empty;

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        

        public StoreContext(string connectionString)
        {
            this.connectionString = connectionString;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                //
                //настройка используемой БД
                optionsBuilder.UseSqlServer(connectionString);
                
            }
        }
    }
}
