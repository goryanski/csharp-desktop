using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CarShowRoomHelper
{
    class CarsSorter
    {
        enum Act { INCREASE = 1, DECREASE }

        CarsStorage carsStorage;
        public CarsSorter() => carsStorage = CarsStorage.Instance;

        public void Start()
        {
            int select = -1; ;
            while (select != 0)
            {
                Console.Clear();

                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Sorting(select);

                if (select != 0)
                {
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();
                }
            }
        }
        void Menu()
        {
            Console.WriteLine("[1] Sort by increasing");
            Console.WriteLine("[2] Sort by descending");
            Console.WriteLine("[0] Exit to main menu");
            Console.Write("Your choose: ");
        }
        void Sorting(int select)
        {
            List<Car> sortedList = null;

            switch (select)
            {
                case (int)Act.INCREASE:
                    sortedList = carsStorage.Cars.OrderBy(car => car.Mark).ToList();
                    break;
                case (int)Act.DECREASE:
                    sortedList = carsStorage.Cars.OrderByDescending(car => car.Mark).ToList();
                    break;
            }

            if(select != 0)
            {
                new CarsSearcher().ShowResult(sortedList);
            }           
        }
    }
}
