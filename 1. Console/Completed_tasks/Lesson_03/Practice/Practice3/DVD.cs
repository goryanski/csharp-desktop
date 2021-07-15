using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class DVD : Storage
    {
        public int Type { get; set; }

        public override void CopyData()
        {
            Console.WriteLine("DVD Copy Data");
        }

        public override void DeviceInfo()
        {
            Console.WriteLine("DVD info");
        }

        public override double GetFreeMemory()
        {
            double freeMemory = 0.0;
            return freeMemory;
        }

        public override double GetMemoryVolume()
        {
            double volume;
            if (Type == 1)
            {
                volume = 4.7;
            }
            else
            {
                volume = 9;
            }
            return volume;
        }
    }
}
