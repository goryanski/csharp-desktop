using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Money
    {
        public decimal Cash { get; set; }

        public static Money operator + (Money summa1, Money summa2)
        {
            return new Money
            {
                Cash = summa1.Cash + summa2.Cash              
            };
        }

        public static Money operator -(Money summa1, Money summa2)
        {          
            return new Money
            {
                Cash = summa1.Cash - summa2.Cash
            };
        }

        public static Money operator /(Money summa1, Money summa2)
        {
            return new Money
            {
                Cash = summa1.Cash / summa2.Cash
            };
        }

        public static Money operator *(Money summa1, Money summa2)
        {
            return new Money
            {
                Cash = summa1.Cash * summa2.Cash
            };
        }

        public static Money operator ++(Money summa)
        {
            return new Money
            {
                Cash = summa.Cash + 0.01m 
            };
        }

        public static Money operator --(Money summa)
        {
            return new Money
            {
                Cash = summa.Cash - 0.01m
            };
        }

        public static bool operator >(Money summa1, Money summa2)
        {
            return summa1.Cash > summa2.Cash;
        }
        public static bool operator <(Money summa1, Money summa2)
        {
            return !(summa1 > summa2);
        }

        public static bool operator ==(Money summa1, Money summa2)
        {
            return summa1.Cash == summa2.Cash;
        }
        public static bool operator !=(Money summa1, Money summa2)
        {
            return !(summa1 == summa2);
        }

        public override string ToString()
        {
            return $"{Cash}";
        }
    }
}
