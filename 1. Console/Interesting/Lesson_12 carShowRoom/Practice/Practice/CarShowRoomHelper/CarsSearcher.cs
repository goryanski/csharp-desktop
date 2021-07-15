using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.CarShowRoomHelper;

namespace Practice.CarShowRoomHelper
{
    class CarsSearcher
    {
        enum Act
        {
            BY_MARK = 1,
            BY_MARK_AND_MODEL,
            BY_COLOR,
            BY_PRICE
        }

        CarsStorage carsStorage;
        public CarsSearcher() => carsStorage = CarsStorage.Instance;

        public void Start()
        {
            int select = -1; ;
            while (select != 0)
            {
                Console.Clear();

                Menu();
                int.TryParse(Console.ReadLine(), out select);
                Action(select);

                if(select != 0)
                {
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();
                }           
            }
        }
        void Menu()
        {
            Console.WriteLine("[1] Search by mark");
            Console.WriteLine("[2] Search by mark and model");
            Console.WriteLine("[3] Search by color");
            Console.WriteLine("[4] Search by price");   
            Console.WriteLine("[0] Exit to main menu");
            Console.Write("Your choose: ");
        }
        void Action(int select)
        {
            switch (select)
            {
                case (int)Act.BY_MARK:
                    SearchByMark();
                    break;
                case (int)Act.BY_MARK_AND_MODEL:
                    SearchByMarkAndModel();
                    break;
                case (int)Act.BY_COLOR:
                    SearchByColor();
                    break;
                case (int)Act.BY_PRICE:
                    SearchByPrice();
                    break;
            }
        }

        void SearchByMark()
        {
            string mark = EnterMark();
            var carsByMark = carsStorage.Cars.Where(car => car.Mark.Equals(mark)).ToList();
            ShowResult(carsByMark);
        }

        void SearchByMarkAndModel()
        {
            string mark = EnterMark();
            Console.Write("\nEnter model: ");
            string model = Console.ReadLine();

            var carsByMarkAndModel = carsStorage.Cars.Where(car => car.Mark.Equals(mark)
            && car.Model.Equals(model)).ToList();

            ShowResult(carsByMarkAndModel);
        }

        void SearchByColor()
        {
            Console.Write("\nEnter color: ");
            string color = Console.ReadLine();
            var carsByColor = carsStorage.Cars.Where(car => car.Color.Equals(color)).ToList();
            ShowResult(carsByColor);
        }

        void SearchByPrice()
        {
            Console.Write("\nEnter min price: ");
            int minPrice;
            int.TryParse(Console.ReadLine(), out minPrice);
            Console.Write("\nEnter max price: ");
            int maxPrice;
            int.TryParse(Console.ReadLine(), out maxPrice);

            var carsbyPrice = carsStorage.Cars.Where(car => car.Price >= minPrice && car.Price <= maxPrice).ToList();

            ShowResult(carsbyPrice);
        }

        public void ShowResult(List<Car> cars)
        {
            if (cars.Count > 0)
            {
                int count = 0;
                cars.ForEach((car) =>
                {
                    Console.WriteLine($"{++count}) {car}");
                });
            }
            else
            {
                Console.WriteLine("There're no such cars");
            }
        }

        string EnterMark()
        {
            Console.Write("\nEnter mark: ");
            return Console.ReadLine();
        }
    }
}
