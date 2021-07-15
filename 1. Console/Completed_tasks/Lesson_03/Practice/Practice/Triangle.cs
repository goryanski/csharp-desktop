using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Triangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double FigureArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            double S = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = SideA + SideB + SideC;
            return P;
        }
    }
}
