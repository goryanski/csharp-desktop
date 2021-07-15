using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class HouseProject
    {
        public int Basement { get; set; }
        public int Door { get; set; }
        public int Roof { get; set; }
        public int Walls { get; set; }
        public int Windows { get; set; }

        public HouseProject()
        {
            Basement = 1;
            Door = 1;
            Roof = 1;
            Walls = 4;
            Windows = 4;
        }

        public bool IsHouseBuilt()
        {
            return Basement == 0 && Door == 0 && Roof == 0 && Walls == 0 && Windows == 0;
        }
    }
}
