using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class CommonFigure
    {
        public Figure [] Figure { get; set; }

        public double GetArea(params Figure[] items)
        {
            Figure = items;

            double totalArea = 0.0;
            foreach (var item in items)
            {
                totalArea += item.FigureArea();
            }
            return totalArea;
        }
    }
}
