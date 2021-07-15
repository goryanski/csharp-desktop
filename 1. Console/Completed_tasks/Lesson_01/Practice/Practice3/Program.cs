using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Задание 3.
Числовые значения символов нижнего регистра в коде ASCII
отличаются от значений символов верхнего регистра на
величину 32. Используя эту информацию, написать программу, которая считывает с клавиатуры и конвертирует 
все символы нижнего регистра в символы верхнего регистра и наоборот.
 */

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text:");

            string text = Console.ReadLine();

            // создадим массив символов и перепишем в него полученную строку
            char[] newText = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                newText[i] = text[i];
            }

            char ch;
            int  code;


            // если это буква, то будем менять регистр (прибавляя или отнимая 32), и перезаписывать символ в массиве символов
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    code = Convert.ToInt32(text[i]);
                    ch = Convert.ToChar(code + 32);
                    newText[i] = ch;
                }
                else if(text[i] >= 'a' && text[i] <= 'z')
                {
                    code = Convert.ToInt32(text[i]);
                    ch = Convert.ToChar(code - 32);
                    newText[i] = ch;
                }
            }

            foreach (var item in newText)
            {
                Console.Write(item);
            }
            Console.WriteLine();



            Console.Read();
        }
    }
}
