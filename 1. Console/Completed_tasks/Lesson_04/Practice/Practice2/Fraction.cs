using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            double f1 = (double)fraction1.Numerator / fraction1.Denominator;
            double f2 = (double)fraction2.Numerator / fraction2.Denominator;
            return f1 > f2; 
        }
        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 > fraction2);
        }


        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Numerator == fraction2.Numerator && fraction1.Denominator == fraction2.Denominator;
        }
        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }


        public static implicit operator Fraction(double number)
        {            
            return new Fraction
            {
                Numerator = (int)number,
                Denominator = ConvertToDenominator(number)
            };        
        }

        public static explicit operator double(Fraction fraction)
        {
            double number = (double)fraction.Numerator / fraction.Denominator;
            return number;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }


        public static int ConvertToDenominator(double number)
        {
            string buff = Convert.ToString(number);

            // после перевода в строку разделителем между целой частью и дробной стала запятая. найдем ее в строке и вырежем все что стоит после нее в знаменатель
            int dot = buff.IndexOf(',');
            string denominator = buff.Substring(dot + 1);

            return Convert.ToInt32(denominator);
        }
 
    }
}
