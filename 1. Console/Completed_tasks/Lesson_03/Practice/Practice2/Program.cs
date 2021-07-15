using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {

            Drink[] allProducts = new Drink[]
            {
                new Beer("beer", "bb", 1.5, 30, 6) { State = "sold" },
                new Milk("milk", "ee", 2, 25, 3.2) { State = "in stock" },
                new Lemonade("lemonade", "yy", 1, 20, "apple") { State = "written off" }
            };

            ProductManager manager = new ProductManager(allProducts);
            manager.ShowSold();
            manager.ShowExists();
            manager.ShowWrittenOff();
            manager.ShowTransferred();


            Console.Read();
        }
    }
}
