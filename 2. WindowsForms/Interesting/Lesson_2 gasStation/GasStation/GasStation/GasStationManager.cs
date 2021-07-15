using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GasStation
{
    class GasStationManager
    {
        public List<string> Marks { get; set; }
        public Dictionary<string, string> Prices { get; set; }

        public GasStationManager()
        {
            Marks = new List<string> { "A92", "A95", "A98", "A100" };
            Prices = new Dictionary<string, string>
            {
                { "A92", "23,64" },
                { "A95", "24,38" },
                { "A98", "25,49" },
                { "A100", "28,51" }
            };
        }

        public bool CheckGasCount(string gasCount)
        {
            if (Regex.IsMatch(gasCount, "^[1-9][0-9]{0,3}$"))
            {
                return true;
            }
            return false;
        }
      
        public string CalcSumByCount(string gasCount, string gasPrice)
        {
            return (double.Parse(gasCount) * double.Parse(gasPrice)).ToString();
        }    

        public bool CheckGasSum(string gasSum)
        {
            if (Regex.IsMatch(gasSum, "^[1-9][0-9,]{1,16}$"))
            {
                return true;
            }
            return false;
        }

        public string CalcSumByMoney(string gasSum, string gasPrice)
        {
            return (double.Parse(gasSum) / double.Parse(gasPrice)).ToString();
        }     
    }
}
