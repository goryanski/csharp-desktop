using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class CrashPlaneException : Exception
    {
        public CrashPlaneException(string str) : base(str += "\nThe plane crashed!")
        {
        }
    }
}
