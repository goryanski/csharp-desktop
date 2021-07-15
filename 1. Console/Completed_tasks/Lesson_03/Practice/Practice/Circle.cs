using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Circle : Figure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double FigureArea()
        {
            double S = 3.14 * Radius * Radius;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = 2 * 3.14 * Radius;
            return P;
        }
    }
}
