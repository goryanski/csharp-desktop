using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Straight<T> where T : struct
    {
        Point<T> point1;
        Point<T> point2;

        public Straight(Point<T> p1, Point<T> p2)
        {
            point1 = p1;
            point2 = p2;
        }
        public Straight(T x1, T y1, T x2, T y2) 
        {
            point1 = new Point<T>(x1, y1);
            point2 = new Point<T>(x2, y2);
        }

        public override string ToString()
        {
            return $"Point1 = {point1}, Point2 = {point2}";
        }
    }
}
