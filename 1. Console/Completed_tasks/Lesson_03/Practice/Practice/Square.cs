using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Square : Figure
    {
        public double SideA { get; set; }

        public Square(double sideA)
        {
            SideA = sideA;
        }

        public override double FigureArea()
        {
            double S = SideA * SideA;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = SideA * 4;
            return P;
        }
    }
}
