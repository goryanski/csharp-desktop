using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем любое кол-во фигур
            Parallelogram parallelogram = new Parallelogram(8.5, 4.3, 4);
            Rhombus rhombus = new Rhombus(8.5, 10);
            Rectangle rectangle = new Rectangle(10, 5);
            Square square = new Square(9);
            Triangle triangle = new Triangle(6, 8, 10.5);


            CommonFigure commonFigure = new CommonFigure();

            // передаем в параметрах любое кол-во фигур
            double totalArea = commonFigure.GetArea(parallelogram, rhombus, rectangle, square, triangle);
            Console.WriteLine($"Quantity of figures: {commonFigure.Figure.Length}\nTotal area: {totalArea}");


            Console.Read();
        }
    }
}
