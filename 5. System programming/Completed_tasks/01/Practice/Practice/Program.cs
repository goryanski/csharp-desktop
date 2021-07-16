using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {               
                using (var stream = new FileStream("Lorem.txt", FileMode.Open, FileAccess.Read))
                {
                    byte[] buff = new byte[100];
                    int countBytes = stream.Read(buff, 0, buff.Length);

                    string str2 = Encoding.UTF8.GetString(buff, 0, countBytes);
                    Console.WriteLine(str2);
                }
            }));

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
