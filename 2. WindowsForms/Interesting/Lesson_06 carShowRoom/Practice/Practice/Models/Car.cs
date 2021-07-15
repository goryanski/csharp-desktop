using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    [Serializable]
    public class Car : ICloneable
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public Decimal Price { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public string PicturePath { get; set; }

        public object Clone()
        {
            return new Car
            {
                Mark = this.Mark,
                Model = this.Model,
                Price = this.Price,
                Color = this.Color,
                Country = this.Country,
                PicturePath = this.PicturePath
            };
        }

        public void Copy(Car from)
        {
            Mark = from.Mark;
            Model = from.Model;
            Price = from.Price;
            Color = from.Color;
            Country = from.Country;
            PicturePath = from.PicturePath;
        }

        public override string ToString()
        {
            return $"{Mark} {Model}   (Price: {Price})";
        }

        public string ShowDetailedInfo()
        {
            return $"Mark - {Mark}\n" +
                $"Model - {Model}\n" +
                $"Price - {Price}\n" +
                $"Color - {Color}\n" +
                $"Country - {Country}";
        }
    }
}
