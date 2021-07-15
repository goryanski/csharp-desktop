using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Wall : IPart
    {
        public IPart GetPart()
        {
            return new Wall();
        }
    }
}
