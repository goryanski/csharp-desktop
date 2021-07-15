using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice 
{
    class Basement : IPart
    {
        public IPart GetPart()
        {
            return new Basement();
        }
    }
}
