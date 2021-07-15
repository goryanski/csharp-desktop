using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Location
    {
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public WeatherInfo[] Weather { get; set; }
    }
}
