using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Lemonade : Drink
    {
        public string Taste { get; set; }

        public Lemonade(string name, string brandName, double bottleVolume, decimal price, string taste)
            : base(name, brandName, bottleVolume, price)
        {
            Taste = taste;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Taste: {Taste}\n");
        }
    }
}
