using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class InvalidPilotException : Exception
    {
        public InvalidPilotException() : base("\nСумма штрафов превысила 1000\nPilot is not allowed to fly")
        {
        }
    }
}
