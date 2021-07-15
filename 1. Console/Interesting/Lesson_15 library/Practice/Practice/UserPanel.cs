using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class UserPanel
    {
        enum Act
        {
            ADD = 1,
            DELETE,
            EDIT,
            SHOW
        }

        Library library = new Library();

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
            Console.WriteLine("[4] Show all books");
            Console.WriteLine("[0] Log out");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    library.AddBook();
                    break;
                case (int)Act.DELETE:
                    library.DeleteBook();
                    break;
                case (int)Act.EDIT:
                    library.EditBook();
                    break;
                case (int)Act.SHOW:
                    library.ShowBooks();
                    break;
            }
        }
    }
}
