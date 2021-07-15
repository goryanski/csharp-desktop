using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Milk : Drink
    {
        public double FatContent { get; set; }

        public Milk(string name, string brandName, double bottleVolume, decimal price, double fatContent)
            : base(name, brandName, bottleVolume, price)
        {
            FatContent = fatContent;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Fat content: {FatContent}\n");
        }
    }
}
