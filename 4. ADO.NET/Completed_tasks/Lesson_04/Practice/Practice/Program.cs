using System;
using System.Linq;
using Practice.Models.Database;
using Practice.Models.Database.Entities;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {             
                //C
                ctx.Cars.Add(new Car { Mark = "Lada", Model = "10", Price = 10_000, Color = "Silver" });
                ctx.SaveChanges();

                //R
                var cars = ctx.Cars.ToList();

                //U
                var car = ctx.Cars.FirstOrDefault(entity => entity.Id == 2);
                car.Model = $"New_{car.Model}";
                ctx.SaveChanges();

                //D
                var car2 = ctx.Cars.FirstOrDefault(entity => entity.Id == 1);
                ctx.Cars.Remove(car2);
                ctx.SaveChanges();
            }
        }
    }
}
