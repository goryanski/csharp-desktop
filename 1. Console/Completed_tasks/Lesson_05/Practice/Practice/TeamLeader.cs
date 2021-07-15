using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class TeamLeader : IWorker
    {       
        public void CheckBuild()
        {
            Console.WriteLine("TeamLeader is checking the build");
        }

        public void MakeReport()
        {
            Console.WriteLine("House is built");
        }


    }
}
