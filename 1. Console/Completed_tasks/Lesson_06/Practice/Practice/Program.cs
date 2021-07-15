using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Money money1 = new Money { Cash = 10.4m };
            Money money2 = new Money { Cash = 8.25m };
            Money money3 = new Money();

            // исключение может возникнуть при вычетании сумм 

            if (money1 < money2)
            {
                throw new BancrotException("Result can't be < 0. You can't do substraction");
            }      

            try
            {
                money3 = money1 - money2;

                Console.WriteLine($"Substraction complete. money3 = {money3}");
            }
            catch (BancrotException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // так же исключение может возникнуть при декременте 
            
            money1.Cash = 0;

            try
            {
                money3 = --money1;
                CheckMoney(money3);

                Console.WriteLine($"Decrement complete. money3 = {money3}");
            }
            catch (BancrotException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }

        static void CheckMoney(Money money)
        {
            if (money.Cash < 0)
            {
                throw new BancrotException("Result can't be < 0. You can't use -- if money = 0");
            }
        }
    }
}
