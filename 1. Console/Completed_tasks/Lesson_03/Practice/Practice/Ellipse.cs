using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Ellipse : Figure
    {
        public double RadiusA { get; set; }
        public double RadiusB { get; set; }

        public Ellipse(double radiusA, double radiusB)
        {
            RadiusA = radiusA;
            RadiusB = radiusB;
        }

        public override double FigureArea()
        {
            double S = 3.14 * RadiusA * RadiusB;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = (4 * 3.14 * RadiusA * RadiusB + (RadiusA - RadiusB)) / (RadiusA + RadiusB);
            return P;
        }
    }
}
