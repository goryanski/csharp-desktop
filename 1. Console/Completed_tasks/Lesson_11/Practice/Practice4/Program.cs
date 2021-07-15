using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!KeyExists(word, dictionary))
                {
                    dictionary.Add(word, CountRepeats(word, words));
                }              
            }

            ShowResult(dictionary);
        }

        static int CountRepeats(string key, string[] words)
        {
            int counter = 0;
            foreach (var word in words)
            {
                if(word == key)
                {
                    counter++;
                }
            }
            return counter;
        }

        static bool KeyExists(string searchWord, Dictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                if(item.Key == searchWord)
                {
                    return true;
                }
            }
            return false;
        }

        static void ShowResult(Dictionary<string, int> dictionary)
        {
            Console.WriteLine("[Word] - [count repeats]");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
