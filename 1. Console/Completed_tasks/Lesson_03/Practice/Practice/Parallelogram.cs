using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice 
{
    class Parallelogram : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Height { get; set; }

        public Parallelogram(double sideA, double sideB, double height)
        {
            SideA = sideA;
            SideB = sideB;
            Height = height;
        }

        public override double FigureArea()
        {
            double S = SideA * Height;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = (SideA + SideB) * 2;
            return P;
        }
    }
}
