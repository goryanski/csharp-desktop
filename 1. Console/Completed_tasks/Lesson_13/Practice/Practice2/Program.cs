using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice2
{
    // 3.Составьте регулярное выражения для поиска слов, которые начинаются с заданной буквы
    // и
    // 6. Дан текст, найдите все слова начинающиеся на A и выведите их на экран

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            Console.WriteLine();
            Console.WriteLine(text);

            Console.Write("\nEnter first letter to find a word: ");
            string firstLetter = Console.ReadLine();

            string reg = @"\b[][a-zA-Z]{1,}\b";
            string newReg = reg.Insert(3, firstLetter);


            var coll = Regex.Matches(text, newReg);
            if (coll.Count > 0)
            {
                foreach (Match item in coll)
                {
                    Console.WriteLine(item.Value);
                }
            }
            else
            {
                Console.WriteLine("No matches");
            }

            Console.Read();
        }
    }
}
