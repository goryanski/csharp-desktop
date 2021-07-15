using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class BancrotException : Exception
    {
        public BancrotException(string msg) : base(msg) { }
    }
}
