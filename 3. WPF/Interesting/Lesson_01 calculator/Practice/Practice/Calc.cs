using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Calc
    {
        public double Result { get; set; }
        public string Operation { get; set; }

        public string Calculate(string text)
        {
            switch (Operation)
            {
                case "+":
                    text = (Result + double.Parse(text)).ToString();
                    break;
                case "-":
                    text = (Result - double.Parse(text)).ToString();
                    break;
                case "*":
                    text = (Result * double.Parse(text)).ToString();
                    break;
                case "/":
                    text = (Result / double.Parse(text)).ToString();
                    break;
            }
            return text;
        }
    }
}
