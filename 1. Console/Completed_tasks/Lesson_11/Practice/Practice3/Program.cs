using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            Straight<int> straight = new Straight<int>(2, 4, 6, 8);
            Console.WriteLine(straight);
        }
    }
}
