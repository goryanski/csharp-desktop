using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exam.Config;

namespace Exam
{
    // admin login: admin
    // admin password: 1212

    // user login: igor
    // user password: 1111
    class Program
    {
        static void Main(string[] args)
        {
            LoggerConfig.Config();
            new Application().Start();
        }
    }
}
