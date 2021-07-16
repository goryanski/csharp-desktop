using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.App.helpers;

namespace Practice.App
{
    class BookViewer
    {
        enum Act
        {
            SHOW = 1,
            SHOW_BY_INCR,
            SHOW_BY_DESC,
            SHOW_SELECTED
        }

        ViewHelper viewer = new ViewHelper();

        public void Start()
        {
            int select = -1; ;
            while (select != 0)
            {
                Console.Clear();

                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Action(select);

                if (select != 0)
                {
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();
                }
            }
        }
        void Menu()
        {
            Console.WriteLine("[1] Show all books");
            Console.WriteLine("[2] Show by price increasing");
            Console.WriteLine("[3] Show by price descending");
            Console.WriteLine("[4] Show selected book (with details)");
            Console.WriteLine("[0] Exit to main menu");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.SHOW:
                    viewer.ShowBooks("ByDefault");
                    break;
                case (int)Act.SHOW_BY_INCR:
                    viewer.ShowBooks("ByIncreasing");
                    break;
                case (int)Act.SHOW_BY_DESC:
                    viewer.ShowBooks("ByDescending");
                    break;
                case (int)Act.SHOW_SELECTED:
                    viewer.ShowSelectdBookFullInfo();
                    break;
            }
        }
    }
}
