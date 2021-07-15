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
            Person person = new Person()
            {
                Firstname = "Igor",
                LastName = "Ivanov",
                Age = 25
            };

            
            person.PropertyChangeEvent += Warning;

            person.Firstname = "Vasya";
        }

        
        static void Warning(string name)
        {
            Console.WriteLine($"Person's name was changed to {name}");
        }
    }
}
