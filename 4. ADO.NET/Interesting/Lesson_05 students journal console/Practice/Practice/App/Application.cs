using System;
using System.Collections.Generic;
using System.Text;
using Practice.App.Helpers;

namespace Practice.App
{
    class Application
    {
        enum Act { ADD = 1, MENU }

        JournalEditor journal = new JournalEditor();

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
            Console.WriteLine("[1] Add student into journal");
            Console.WriteLine("[2] Student marks manager");
            Console.WriteLine("[0] Exit");
            Console.Write("Your choose: ");
        }

        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    journal.AddStudent();
                    break;
                case (int)Act.MENU:
                    new MarksManagerMenu().Start();
                    break;
            }
        }
    }
}
