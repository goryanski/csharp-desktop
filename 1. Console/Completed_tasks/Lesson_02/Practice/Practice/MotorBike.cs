using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class MotorBike
    {
        public string Mark { get; set; }
        public int ModelNumber { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public double Speed { get; set; }

        public static int weight;
        public static string material;

        public MotorBike()
        {
            this.Mark = "Unknown";
            this.ModelNumber = 0000;
            this.Color = "Black";
            this.Price = 0;
            this.Speed = 0.0;
        }
        static MotorBike() 
        {
            weight = 100;
            material = "iron";
        }
        
        // поля, которые не передаются в параметрах проинициализируются конструктором по умолчанию
        public MotorBike(string mark, int modelNumber, double speed)
            : this()
        {
            this.Mark = mark;
            this.ModelNumber = modelNumber;
            this.Speed = speed;
        }
        public MotorBike(string color, decimal price)
            : this()
        {
            this.Color = color;
            this.Price = price;
        }
        public MotorBike(string mark, int modelNumber, double speed, string color, decimal price)
            : this(mark, modelNumber, speed)
        {
            this.Color = color;
            this.Price = price;
        }


        public int getWeight() => weight;
        public string getMaterial() => material;


        public void ShowBike()
        {
            Console.WriteLine($"Mark: {Mark} \nModel: {ModelNumber} \nColor: {Color} \nSpeed: {Speed} \nPrice: ${Price}\n");
        }

        public void EditBike()
        {
            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("[1] Mark");
            Console.WriteLine("[2] ModelNumber");
            Console.WriteLine("[3] Color");
            Console.WriteLine("[4] Price");
            Console.WriteLine("[5] Speed");
            Console.WriteLine("[6] Exit");

            int select;
            int.TryParse(Console.ReadLine(), out select);

            while(select < 1 || select > 6)
            {
                Console.WriteLine("Wrong number, try again:");
                int.TryParse(Console.ReadLine(), out select);
            }


            switch(select)
            {
                case 1:
                    Console.WriteLine("Enter mark:");
                    Mark = Console.ReadLine();
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter ModelNumber:");
                        int num;
                        int.TryParse(Console.ReadLine(), out num);
                        ModelNumber = num;
                        break;
                    }
                case 3:
                    Console.WriteLine("Enter Color:");
                    Color = Console.ReadLine();
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter Price:");
                        decimal value;
                        decimal.TryParse(Console.ReadLine(), out value);
                        Price = value;
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter Speed:");
                        double value;
                        double.TryParse(Console.ReadLine(), out value);
                        Speed = value;
                        break;
                    }
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
