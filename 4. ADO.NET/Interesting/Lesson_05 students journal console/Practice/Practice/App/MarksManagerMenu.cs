using System;
using System.Collections.Generic;
using System.Text;
using Practice.App.Helpers;

namespace Practice.App
{
    class MarksManagerMenu
    {
        enum Act
        {
            ADD = 1,
            DELETE,
            EDIT,
            SHOW
        }

        JournalMarksManager editor = new JournalMarksManager();

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
            Console.WriteLine("[1] Add mark");
            Console.WriteLine("[2] Delete mark");
            Console.WriteLine("[3] Edit mark");
            Console.WriteLine("[4] Show marks");
            Console.WriteLine("[0] Back");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    editor.AddMark();
                    break;
                case (int)Act.DELETE:
                    editor.DeleteMark();
                    break;
                case (int)Act.EDIT:
                    editor.EditMark();
                    break;
                case (int)Act.SHOW:
                    editor.ShowMarks();
                    break;
            }
        }
    }
}
