using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Trapeze : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double SideD { get; set; }
        public double Height { get; set; }

        public Trapeze(double sideA, double sideB, double sideC, double sideD, double height)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideB;
            SideD = sideB;
            Height = height;
        }

        public override double FigureArea()
        {
            double S = ((SideA + SideB) * Height) / 2;
            return S;
        }

        public override double FigurePerimeter()
        {
            double P = SideA + SideB + SideC + SideD;
            return P;
        }
    }
}
