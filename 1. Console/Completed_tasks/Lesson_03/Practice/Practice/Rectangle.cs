using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Rectangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;  
        }

        public override double FigureArea()
        {
            double S = SideA * SideA;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = (SideA + SideB) * 2;
            return P;
        }
    }
}
