using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public Decimal Price { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Mark - {Mark}, " +
                $"Model - {Model}, " +
                $"Price - {Price}, " +
                $"Color - {Color}, " +
                $"Country - {Country}";
        }
    }
}
