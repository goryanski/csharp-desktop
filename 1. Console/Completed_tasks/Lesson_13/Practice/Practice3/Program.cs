using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice3
{
    // 4.Составьте регулярное выражение для проверки номера телефона

    class Program
    {
        static void Main(string[] args)
        {            
            string phoneNumber = "+380934094350";

            // проверка на номер телефона украинского оператора
            // дадим названия группам для лучшей читабельности
            string phoneChecking = @"^[+](?<country>[3][8][0])(?<operator>([9][3])|([6][3])|([9][9])|([5][0])|([9][5])|([6][6])|([9][7])|([9][6])|([6][7])|([9][8])|([6][8]))(?<body>[\d]{7})$";


            if (Regex.IsMatch(phoneNumber, phoneChecking))
            {
                Console.WriteLine("Phone number - Correct");
                Console.WriteLine($"Your operator is {ShowOperator(phoneNumber, phoneChecking)}");
            }
            else
            {
                Console.WriteLine("Phone number - Incorrect");
            }

            Console.Read();
        }


        static string ShowOperator(string phoneNumber, string regularExpression)
        {
            var mobileOperator = Regex.Match(phoneNumber, regularExpression);

            string value = mobileOperator.Groups["operator"].Value;
            
            if (value == "93" || value == "63")
            {
                return "Life";
            }
            else if(value == "99" || value == "50" || value == "95" || value == "66")
            {
                return "Vodafone";
            }
            else
            {
                return "Kievstar";
            }
        }
    }
}
