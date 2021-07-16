using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.App.helpers;

namespace Practice.App
{
    class BookShopApp
    {
        enum Act
        {
            ADD = 1,
            DELETE,
            EDIT,
            SHOW
        }

        BooksEditor editor = new BooksEditor();

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
            Console.WriteLine("[1] Add book");
            Console.WriteLine("[2] Delete book");
            Console.WriteLine("[3] Edit book");
            Console.WriteLine("[4] Show books");
            Console.WriteLine("[0] Exit");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    editor.AddBook();
                    break;
                case (int)Act.DELETE:
                    editor.DeleteBook();
                    break;
                case (int)Act.EDIT:
                    editor.EditBook();
                    break;
                case (int)Act.SHOW:
                    new BookViewer().Start();
                    break;
            }
        }
    }
}
