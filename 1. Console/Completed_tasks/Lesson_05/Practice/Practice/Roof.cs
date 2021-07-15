using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Roof : IPart
    {
        public IPart GetPart()
        {
            return new Roof();
        }
    }
}
