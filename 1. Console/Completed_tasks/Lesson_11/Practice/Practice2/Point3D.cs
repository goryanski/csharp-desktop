using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Point3D : Point2D<int>
    {
        public int Z { get; set; }

        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Z = {Z}";
        }
    }
}
