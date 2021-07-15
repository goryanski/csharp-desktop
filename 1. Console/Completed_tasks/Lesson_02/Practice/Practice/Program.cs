using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            MotorBike[] bikes = new MotorBike[]
            {
                new MotorBike("aaa", 2333, 16.7, "blue", 10000),
                new MotorBike("zzz", 3434, 17.4, "yellow", 10000),
                new MotorBike("rrr", 8977, 15.3),
                new MotorBike("red", 20000),
                new MotorBike(),
            };

            ShowListBikes(bikes);

            // просто выведем статические поля что бы они как-то использовались
            Console.WriteLine($"Weight: {bikes[2].getWeight()}\nMaterial: {bikes[2].getMaterial()}");


            Console.WriteLine("Do you want to edit some car?\n[1] Yes\n[2] No");

            int select = int.Parse(Console.ReadLine());

            if (select == 1)
            {
                Console.WriteLine("Choose bike:");
                int numBike = int.Parse(Console.ReadLine());
                bikes[numBike - 1].EditBike();
                ShowListBikes(bikes);
            }

            

            Console.Read();
        }

        static void ShowListBikes(MotorBike[] bikes)
        {
            int counter = 0;
            foreach (var item in bikes)
            {
                Console.WriteLine($"[{++counter}]:");
                item.ShowBike();
            }
        }
    }
}
