using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class HDD : Storage
    {
        public double MemoryVolume { get; set; }
        public double PartitionQuantity { get; set; }

        public override void CopyData()
        {
            Console.WriteLine("HDD Copy Data");
        }

        public override void DeviceInfo()
        {
            Console.WriteLine("HDD info");
        }

        public override double GetFreeMemory()
        {
            double freeMemory = 0.0;
            return freeMemory;
        }

        public override double GetMemoryVolume() => MemoryVolume;
    }
}
