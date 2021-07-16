using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RG3HTFI;Initial Catalog=SchoolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Car>().HasData(new Car[] 
            { 
                new Car { Id = 1, Mark = "BMW", Model = "X5", Price = 20_000, Color = "Black" },
                new Car { Id = 2, Mark = "Lexus", Model = "A5ss", Price = 30_000, Color = "Green" },
                new Car { Id = 3, Mark = "Nisan", Model = "xtt8", Price = 10000, Color = "Red" },

            });
            modelBuilder.Entity<Car>().Property(c => c.Mark)
                .HasMaxLength(30)
                .HasDefaultValue("Unknown")
                .IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Model)
               .HasMaxLength(30)
               .HasDefaultValue("Unknown")
               .IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Color)
               .HasMaxLength(30)
               .HasDefaultValue("Unknown")
               .IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Price)
               .HasDefaultValue(5_000)
               .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
