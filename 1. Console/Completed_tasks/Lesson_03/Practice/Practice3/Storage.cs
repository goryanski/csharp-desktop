using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    abstract class Storage
    {
        public string StorageName { get; set; }
        public string Model { get; set; }
        public double Speed { get; set; }

        public abstract double GetMemoryVolume();
        public abstract void CopyData();
        public abstract double GetFreeMemory();
        public abstract void DeviceInfo();
    }
}
