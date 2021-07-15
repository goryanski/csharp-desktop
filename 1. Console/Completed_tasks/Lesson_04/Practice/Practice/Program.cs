using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product milk = new Product
            {
                Name = "milk",
                Mark = "aa",
                Price = 40
            };

            Product beer = new Product
            {
                Name = "beer",
                Mark = "bb",
                Price = 50
            };


            if (milk == beer)
            {
                Console.WriteLine("Is the same");
            }
            else if(milk < beer)
            {
                Console.WriteLine("Beer is more expensive");
            }
            else if(milk > beer)
            {
                Console.WriteLine("Milk is more expensive");
            }           
        }
    }
}
