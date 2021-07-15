using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Flash : Storage
    {      
        public double MemoryVolume { get; set; }


        public override void CopyData()
        {
            Console.WriteLine("Flash Copy Data");
        }

        public override void DeviceInfo()
        {
            Console.WriteLine("Flash info");
        }

        public override double GetFreeMemory()
        {
            double freeMemory = 0.0;
            return freeMemory;
        }

        public override double GetMemoryVolume() => MemoryVolume;
    }
}
