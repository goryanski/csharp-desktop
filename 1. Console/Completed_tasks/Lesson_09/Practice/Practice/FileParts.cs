using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    // в этот класс мы распарсим файл, что бы потом удобно получать доступ к разным частям файла через поля класса 
    class FileParts
    {
        public string[] PersonInfo { get; set; }
        public double[,] DoubleArray { get; set; }
        public int[,] IntArray { get; set; }
        public DateTime Date { get; set; }

        public void Parsing(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    // получение PersonInfo
                    string line = reader.ReadLine();
                    PersonInfo = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // получение DoubleArray
                    int row = int.Parse(reader.ReadLine());
                    int col = int.Parse(reader.ReadLine());
                    DoubleArray = new double[row, col];
                    string arrLine;
                    string[] elements;

                    for (int i = 0; i < row; i++)
                    {
                        arrLine = reader.ReadLine();
                        elements = arrLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < col; j++)
                        {
                            DoubleArray[i, j] = double.Parse(elements[j]);
                        }
                    }

                    // получение IntArray
                    row = int.Parse(reader.ReadLine());
                    col = int.Parse(reader.ReadLine());
                    IntArray = new int[row, col];

                    arrLine = reader.ReadLine();
                    elements = arrLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int count = 0;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            IntArray[i, j] = int.Parse(elements[count++]);
                        }
                    }

                    //получение Date
                    Date = DateTime.Parse(reader.ReadLine());                   
                }
            }
            else
            {
                Console.WriteLine($"File {path} doesn't exist\n");
            }
        }

        public void ShowParsedFile()
        {
            ArrayHelper helper = new ArrayHelper();

            Console.WriteLine("\nFile was parsed to class \"FileParts\"");

            Console.WriteLine("\nPerson info:");
            helper.ShowPersonInfo(PersonInfo);

            Console.WriteLine("\nDouble array:");
            helper.PrintArray(DoubleArray);

            Console.WriteLine("\nInt array:");
            helper.PrintArray(IntArray);

            Console.WriteLine("\nDate of creation:");
            Console.WriteLine(Date);
        }
    }
}
