using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Drink
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public double BottleVolume { get; set; }
        public decimal Price { get; set; }
        public string State { get; set; }

        
        public Drink(string name, string brandName, double bottleVolume, decimal price)
        {
            Name = name;
            BrandName = brandName;
            BottleVolume = bottleVolume;
            Price = price;
        }

        public virtual void Show()
        {
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Brand name: {BrandName}");
            Console.WriteLine($"Bottle volume: {BottleVolume}");
            Console.WriteLine($"Price: {Price}");
        }
    }
}
