using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice
{
    class ArrayHelper
    {
        readonly Random rand = new Random();
        public double[,] GenerateDoubleArray(int rows, int cols)
        {
            double[,] dArr = new double[rows, cols];

            for (int i = 0; i < dArr.GetLength(0); i++)
            {
                for (int j = 0; j < dArr.GetLength(1); j++)
                {
                    dArr[i, j] = Math.Round((double)(rand.Next(1, 10) / 2.2), 2);
                }
            }
            return dArr;
        }

        public int[,] GenerateIntArray(int rows, int cols)
        {
            int[,] dArr = new int[rows, cols];

            for (int i = 0; i < dArr.GetLength(0); i++)
            {
                for (int j = 0; j < dArr.GetLength(1); j++)
                {
                    dArr[i, j] = rand.Next(0, 100);
                }
            }
            return dArr;
        }

        public string[] CreatePersonInfo()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter second name: ");
            string secondName = Console.ReadLine();

            Console.Write("Enter middle name: ");
            string middleName = Console.ReadLine();

            Console.Write("Enter birth: ");
            string birth = Console.ReadLine();
            // удалим на всякий случай пробелы, если их вводили, это нужно для корректного считывания из файла
            birth = birth.Replace(" ", string.Empty);

            string[] info = new string[] { firstName, secondName, middleName, birth };

            return info;
        }

        public void WritePersonInfo(string[] info, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                for (int i = 0; i < info.Length; i++)
                {
                    writer.Write(info[i]);
                    writer.Write(" ");
                }
                writer.Write("\n");
            }
        }

        // bool inOneLine - если двумерный массив нужно записать в одну линию
        public void AppendArray<T>(T[,] arr, string fileName, bool inOneLine = false)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine(arr.GetLength(0));
                writer.WriteLine(arr.GetLength(1));

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        writer.Write(arr[i, j]);
                        writer.Write(" ");
                    }
                    if (!inOneLine)
                    {
                        writer.Write("\n");
                    }
                }
                if (inOneLine)
                {
                    writer.Write("\n");
                }
            }
        }

        public void PrintArray<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ShowPersonInfo(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
