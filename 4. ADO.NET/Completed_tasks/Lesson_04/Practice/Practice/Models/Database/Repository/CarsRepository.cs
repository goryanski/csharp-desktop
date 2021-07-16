using System;
using System.Collections.Generic;
using System.Text;
using Practice.Models.Database.Entities;

namespace Practice.Models.Database.Repository
{
    public class CarsRepository : BaseRepository<Car>
    {
        public CarsRepository(DatabaseContext ctx) : base(ctx) { }

        public override void Update(Car entity)
        {
            var car = Get(entity.Id);
            car.Mark = entity.Mark;
            car.Model = entity.Model;
            car.Price = entity.Price;
            car.Color = entity.Color;
            context.SaveChanges();
        }
    }
}
