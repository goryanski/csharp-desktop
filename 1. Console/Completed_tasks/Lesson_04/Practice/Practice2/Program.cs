using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction
            {
                Numerator = 1,
                Denominator = 3
            };

            Fraction fraction2 = new Fraction
            {
                Numerator = 1,
                Denominator = 4
            };


            if (fraction1 == fraction2)
            {
                Console.WriteLine("Is the same");
            }
            else if(fraction1 > fraction2)
            {
                Console.WriteLine("fraction1 is bigger");
            }
            else if (fraction1 < fraction2)
            {
                Console.WriteLine("fraction2 is bigger");
            }


            double number = (double)fraction2;
            Console.WriteLine($"\nFraction to number:");
            Console.WriteLine($"Fraction = {fraction2}\nNumber = {number}");


            double num = 81.62;
            Fraction f = num;
            Console.WriteLine($"\nNumber to fraction:");
            Console.WriteLine($"Number = {num}\nFraction = {f}");


            Console.Read();
        }
    }
}
