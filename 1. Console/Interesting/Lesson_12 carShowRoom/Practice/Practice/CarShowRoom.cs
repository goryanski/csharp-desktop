using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.CarShowRoomHelper;

namespace Practice
{
    class CarShowRoom
    {
        CarsStorage carsStorage;
        public CarShowRoom() => carsStorage = CarsStorage.Instance;

        public void AddCar()
        {
            carsStorage.Cars.Add(FillCar());
            Console.WriteLine("Car was added.");
        }

        public void DeleteCar()
        {
            carsStorage.Cars.RemoveAt(SelectCar() - 1);
            Console.WriteLine("Car was deleted.");
        }

        public void EditCar()
        {
            carsStorage.Cars[SelectCar() - 1] = FillCar();
            Console.WriteLine("Car was edited.");
        }

        public void ShowCars()
        {
            if (carsStorage.Cars.Count > 0)
            {
                Console.WriteLine("\nList of all cars:");
                int count = 0;
                carsStorage.Cars.ForEach((car) =>
                {
                    Console.WriteLine($"[{++count}] {car}");
                });
            }
            else
            {
                Console.WriteLine("Car showroom hasn't any cars");
            }
        }
        Car FillCar()
        {
            Console.WriteLine("\nEnter info:");

            Console.Write("Car mark: ");
            string mark = Console.ReadLine();
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Car price: ");
            decimal price;
            decimal.TryParse(Console.ReadLine(), out price);
            Console.Write("Car color: ");
            string color = Console.ReadLine();
            Console.Write("Car country: ");
            string country = Console.ReadLine();

            return new Car { Mark = mark, Model = model, Price = price, Color = color, Country = country };
        }
        int SelectCar()
        {
            ShowCars();
            Console.Write("\nChoose car number: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > carsStorage.Cars.Count)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }
            return select;
        }   
    }
}
