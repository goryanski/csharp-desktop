using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class FileHelper
    {
        public void JustCreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter creator = new StreamWriter(new FileStream(fileName, FileMode.Create)))
                {
                }
                Console.WriteLine($"File {fileName} was created");
            }
            else
            {
                Console.WriteLine($"File {fileName} already exist");
            }
        }

        public void ReadInfo(string fileName)
        {
            string fileContent = null;

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
                {
                    fileContent = reader.ReadToEnd();
                }
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine($"File {fileName} doesn't exist\n");
            }
        }

        public void WriteInfo(string fileName)
        {
            // для повторного вызова ф-ции будем удалять файл, поскольку используем FileMode.Append и у нас информация в файле не перезатирается
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // создаем информацию 
            ArrayHelper arrHelper = new ArrayHelper();
            string[] personInfo = arrHelper.CreatePersonInfo();
            int[,] intArray = new int[2, 3];
            intArray = arrHelper.GenerateIntArray(2, 3);
            double[,] doubleArray = new double[2, 2];
            doubleArray = arrHelper.GenerateDoubleArray(2, 2);

            // записываем информацию
            arrHelper.WritePersonInfo(personInfo, fileName);
            arrHelper.AppendArray(doubleArray, fileName);
            arrHelper.AppendArray(intArray, fileName, true); // его по условию нужно записать в одну линию
            WriteCurrentDate(fileName);

            Console.WriteLine("Info was writed");
        }

         void WriteCurrentDate(string fileName)
         {
            using (StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine(DateTime.Now);
            }
         }

    }
}
