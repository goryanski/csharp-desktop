using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задание 1.
//Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка. Программа должна
//сосчитать количество введенных пользователем пробелов. 

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");

            // инициализируем ch любым символом 
            char ch = 'a';

            ConsoleKeyInfo key;
            int counter = 0;

            while (ch != '.')
            {
                key = Console.ReadKey();
                ch = key.KeyChar;
                if (ch == ' ')
                {
                    counter++;
                }
            }
            Console.WriteLine($"\nNumber of white spaces: {counter}");
        }
    }
}
