using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class ProductManager
    {
        public Drink[] AllProducts { get; set; }

        public ProductManager(Drink[] allProducts)
        {
            AllProducts = allProducts;
        }

        public void ShowSold()
        {
            int f = 0;
            Console.WriteLine("[1] Sold products:");
            foreach (var item in AllProducts)
            {  
                if (item.State.Equals("sold"))
                {
                    item.Show();
                    f = 1;
                }
            }
            if (f == 0)
            {
                Console.WriteLine("There're no sold products");
            }
        }

        public void ShowExists()
        {
            int f = 0;
            Console.WriteLine("[2] Are available:");
            foreach (var item in AllProducts)
            {
                if (item.State.Equals("in stock"))
                {
                    item.Show();
                    f = 1;
                }
            }
            if (f == 0)
            {
                Console.WriteLine("There're no available products");
            }
        }

        public void ShowWrittenOff()
        {
            int f = 0;
            Console.WriteLine("[3] Written off products:");
            foreach (var item in AllProducts)
            {
                if (item.State.Equals("written off"))
                {
                    item.Show();
                    f = 1;
                }
            }
            if (f == 0)
            {
                Console.WriteLine("There're no written off products");
            }
        }

        public void ShowTransferred()
        {
            int f = 0;
            Console.WriteLine("[4] Transferred products:");
            foreach (var item in AllProducts)
            {
                if (item.State.Equals("transferred"))
                {
                    item.Show();
                    f = 1;
                }
            }
            if (f == 0)
            {
                Console.WriteLine("There're no transferred products");
            }
        }
    }
}
