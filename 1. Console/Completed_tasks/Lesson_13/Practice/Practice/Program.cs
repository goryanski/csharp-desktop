using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Составьте регулярное выражения для проверки ввода только цифр
            string digitsOnlyText = "121848822";
            string digitsOnlyReg = @"^[\d]+$";

            if (Regex.IsMatch(digitsOnlyText, digitsOnlyReg))
            {
                Console.WriteLine("Digits only - Correct");
            }
            else
            {
                Console.WriteLine("Digits only - Incorrect");
            }



            // 2. Составьте регулярное выражения для проверки ввода только букв
            string lettersOnlyText = "sdvsdvWSCCCC";
            string lettersOnlyReg = "^[a-zA-Z]+$";

            if (Regex.IsMatch(lettersOnlyText, lettersOnlyReg))
            {
                Console.WriteLine("Letters only - Correct");
            }
            else
            {
                Console.WriteLine("Letters only - Incorrect");
            }

            Console.Read();           
        }
    }
}
