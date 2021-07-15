using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.CarShowRoomHelper;

namespace Practice
{
    class Application
    {
        enum Act
        {
            ADD = 1,
            DELETE,
            EDIT,
            SEARCH,
            SORT,
            SHOW
        }

        CarShowRoom carShowRoom = new CarShowRoom();

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
            Console.WriteLine("[1] Add car");
            Console.WriteLine("[2] Delete car");
            Console.WriteLine("[3] Edit car");
            Console.WriteLine("[4] Search cars");
            Console.WriteLine("[5] Sort by mark");
            Console.WriteLine("[6] Show all cars");
            Console.WriteLine("[0] Exit");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.ADD:
                    carShowRoom.AddCar();
                    break;
                case (int)Act.DELETE:
                    carShowRoom.DeleteCar();
                    break;
                case (int)Act.EDIT:
                    carShowRoom.EditCar();
                    break;
                case (int)Act.SEARCH:
                    new CarsSearcher().Start();
                    break;
                case (int)Act.SORT:
                    new CarsSorter().Start();
                    break;
                case (int)Act.SHOW:
                    carShowRoom.ShowCars();
                    break;                  
            }
        }
    }
}
