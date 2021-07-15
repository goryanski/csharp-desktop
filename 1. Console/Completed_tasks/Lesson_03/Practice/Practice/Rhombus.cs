using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Rhombus : Figure
    {
        public double SideA { get; set; }
        public double Height { get; set; }

        public Rhombus(double sideA, double height)
        {
            SideA = sideA;
            Height = height;
        }

        public override double FigureArea()
        {
            double S = SideA * Height;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = SideA * 4;
            return P;
        }
    }
}
