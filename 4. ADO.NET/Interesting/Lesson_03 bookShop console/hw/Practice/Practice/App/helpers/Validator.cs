using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.App.helpers
{
    public class Validator
    {
        public DateTime SafelyInput(DateTime value)
        {
            DateTime.TryParse(Console.ReadLine(), out value);
            while (value > DateTime.Now || value < DateTime.Now.AddYears(-120))
            {
                Console.Write("Wrong date, try again: ");
                DateTime.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }

        public int SafelyInput(int value)
        {
            int.TryParse(Console.ReadLine(), out value);
            while (value <= 0)
            {
                Console.Write("Wrong value, try again: ");
                int.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }

        public decimal SafelyInput(decimal value)
        {
            decimal.TryParse(Console.ReadLine(), out value);
            while (value <= 0)
            {
                Console.Write("Wrong value, try again: ");
                decimal.TryParse(Console.ReadLine(), out value);
            }
            return value;
        }
    }
}
