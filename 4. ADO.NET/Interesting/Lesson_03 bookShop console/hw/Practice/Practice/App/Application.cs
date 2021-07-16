using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Authentication;

namespace Practice.App
{
    class Application
    {
        enum Act { REGISTRATION = 1, LOGIN }

        AuthenticationService service = new AuthenticationService();

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
            Console.WriteLine("[1] Registration");
            Console.WriteLine("[2] Login");
            Console.WriteLine("[0] Exit");
            Console.Write("Your choose: ");
        }

        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.REGISTRATION:
                    service.Registration();
                    break;
                case (int)Act.LOGIN:
                    service.Login();
                    break;
            }
        }
    }
}
