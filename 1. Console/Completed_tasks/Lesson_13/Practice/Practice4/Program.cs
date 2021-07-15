using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice4
{
    // 5. Составьте регулярное выражение для проверки email

    class Program
    {
        static void Main(string[] args)
        {
            string email = "igorok208@gmail.com";

            string emailChecking = @"^[a-zA-Z0-9][a-zA-Z0-9!#$%&'*+-\/=?^_`{|}~]{2,63}@[a-zA-Z]{2,32}\.[a-zA-Z]{2,16}$";


            if (Regex.IsMatch(email, emailChecking))
            {
                Console.WriteLine("Email - Correct");
            }
            else
            {
                Console.WriteLine("Email - Incorrect");
            }
        }
    }
}
