using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GasStation
{
    class CafeManager
    {
        public Dictionary<string, string> Prices { get; set; }

        public CafeManager()
        {
            // цены будем хранить в словаре для наглядности и что бы удобно было их поменять в случае чего
            Prices = new Dictionary<string, string>
            {
                { "HotDog", "30" },
                { "Hamburger", "35" },
                { "Fries", "35" },
                { "Cola", "20" }
            };
        }

        public bool IsFoodCountValid(string text)
        {
            if (Regex.IsMatch(text, "^[1-9][0-9]{0,1}$"))
            {
                return true;
            }
            return false;
        }
    }
}
