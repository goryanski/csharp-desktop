using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Config;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerConfig.Config();
            new Application().Start();
        }
    }
}
