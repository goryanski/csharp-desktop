using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Даны целые положительные числа A и B (A < B). Вывести
все целые числа от A до B включительно; каждое число
должно выводиться на новой строке; при этом каждое
число должно выводиться количество раз, равное его
значению. Например: если А = 3, а В = 7, то программа
должна сформировать в консоли следующий вывод:
 */

namespace Practice4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number A:");
            int A = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number B (B must be bigger, than A):");
            int B = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int countLoop = B - A + 1;

            for (int i = 0; i < countLoop; i++)
            {
                for (int j = 0; j < A; j++)
                {
                    Console.Write($"{A} ");
                }
                Console.WriteLine();
                A++;
            }
        }
    }
}
