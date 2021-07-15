using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Product
    {
        public string Name { get; set; }
        public string Mark { get; set; }
        public decimal Price { get; set; }


        public static bool operator >(Product prod1, Product prod2)
        {
            return prod1.Price > prod2.Price;
        }
        public static bool operator <(Product prod1, Product prod2)
        {
            return !(prod1 > prod2);
        }

        public static bool operator == (Product prod1, Product prod2)
        {
            return prod1.Price == prod2.Price;
        }
        public static bool operator != (Product prod1, Product prod2)
        {
            return !(prod1 == prod2);
        }
    }
}
