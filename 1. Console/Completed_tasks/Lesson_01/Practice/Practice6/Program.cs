using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    /*
  Сжать массив, удалив из него все 0 и, заполнить освободившиеся справа элементы значениями –1. Потом отсортировать массив в порядке возрастания
  */

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[20];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 5);
            }


            ShowArray(arr);


            int zeroCounter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    zeroCounter++;
                    int tmp = arr[i];
                    arr[i] = arr[arr.Length - 1];
                    arr[arr.Length - 1] = tmp;
                    i--;

                    int[] buff = new int[arr.Length - 1];
                    Array.Copy(arr, buff, arr.Length - 1);

                    arr = buff;
                }
            }


            for (int i = 0; i < zeroCounter; i++)
            {
                int[] buff = new int[arr.Length + 1];
                Array.Copy(arr, buff, arr.Length);
                buff[buff.Length - 1] = -1;
                arr = buff;
            }

            ShowArray(arr);

            Array.Sort(arr);
            ShowArray(arr);

            Console.Read();
        }

        static void ShowArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
 }

