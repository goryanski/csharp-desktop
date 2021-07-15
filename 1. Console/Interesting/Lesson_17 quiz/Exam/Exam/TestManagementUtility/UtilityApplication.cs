using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.TestManagementUtility
{
    class UtilityApplication
    {
        enum Act
        {
            ADD = 1,
            DELETE,
            EDIT
        }

        TestsManagement testManagement = new TestsManagement();

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
            Console.WriteLine("[1] Add test");
            Console.WriteLine("[2] Delete test");
            Console.WriteLine("[3] Edit test");
            Console.WriteLine("[0] Log out");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    testManagement.AddTest();
                    break;
                case (int)Act.DELETE:
                    testManagement.DeleteTest();
                    break;
                case (int)Act.EDIT:
                    new EditMenu().Start();
                    break;
            }
        }
    }
}
