using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.VictorinaApplication
{
    class EditMenu
    {
        enum Act
        {
            BIRTH = 1,
            PASSWORD
        }

        EditInfo editInfo = new EditInfo();

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
            Console.WriteLine("[1] Change birth");
            Console.WriteLine("[2] Change password");
            Console.WriteLine("[0] To main menu");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.BIRTH:
                    editInfo.ChangeBirth();
                    break;
                case (int)Act.PASSWORD:
                    editInfo.ChangePassword();
                    break;
            }
        }
    }
}
