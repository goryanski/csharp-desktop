using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Задание 5.
Дано целое число N (> 0), найти число, полученное при
прочтении числа N справа налево. Например, если было
введено число 345, то программа должна вывести число 543.
 */

namespace Practice5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");

            string number = Console.ReadLine();

            while (!AllDigits(number))
            {
                Console.WriteLine("Number must contains only digits. Try again:");
                number = Console.ReadLine();
            }

            // переведем строку в массив символов что бы воспользоваться методом Reverse массива
            char[] letters = number.ToCharArray();
            Array.Reverse(letters);
            string result = new string(letters);

            // поскольку по заданию нужно найти число то переведем в инт
            int resultInt = int.Parse(result);

            Console.WriteLine(resultInt);
           
     
            Console.Read();
        }

        static bool AllDigits(string str)
        {
            foreach (var ch in str)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
