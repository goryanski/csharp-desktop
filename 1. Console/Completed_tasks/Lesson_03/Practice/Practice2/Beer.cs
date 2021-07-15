using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Beer : Drink
    {
        public double AlcoholСontent { get; set; }

        public Beer(string name, string brandName, double bottleVolume, decimal price, double alcoholСontent) 
            : base(name, brandName, bottleVolume, price)
        {
            AlcoholСontent = alcoholСontent;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Alcohol content: {AlcoholСontent}\n");
        }
    }
}
