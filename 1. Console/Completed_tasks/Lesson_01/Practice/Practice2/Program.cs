using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 Задание 2.
Ввести с клавиатуры номер трамвайного билета (6-значное
число) и про-верить является ли данный билет счастливым
(если на билете напечатано шестизначное число, и сумма
первых трёх цифр равна сумме последних трёх, то этот
билет считается счастливым).
 */

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");

            string ticket = Console.ReadLine();

            while(ticket.Length != 6 || !AllDigits(ticket))
            {
                Console.WriteLine("You must to write 6 numbers without letters, try again: ");
                ticket = Console.ReadLine();
            }

            int part1 = 0;
            int part2 = 0;

            for(int i = 0; i < 3; i++)
            {
                // запишем в переменные сразу сумму первых 3 цифр и вторых 3 цифр
                part1 += int.Parse(ticket.Substring(i, 1));
                part2 += int.Parse(ticket.Substring(i + 3, 1));
            }

            if (part1 == part2)
            {
                Console.WriteLine("Ticket is happy!!!");
            }
            else
            {
                Console.WriteLine("Ticket isn't happy!!!");
            }

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
