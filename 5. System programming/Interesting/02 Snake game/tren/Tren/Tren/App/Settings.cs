using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tren.App
{
    public class Settings
    {
        public static int FieldWidth { get; set; }
        public static int FieldHeight { get; set; }
        public static int SellSize { get; set; }
        public static int Speed { get; set; }

        public Settings()
        {
            FieldWidth = 586;
            FieldHeight = 580;
            SellSize = 30;
            Speed = 150; // чем меньше значение тем быстрее
        }
    }
}
