using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Person : IPropertyChanged
    {
        public event Action<string> PropertyChangeEvent;
       
        private string firstname;
        public string Firstname
        {
            get => Firstname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    firstname = "Unknown";
                }
                else
                {
                    firstname = value;
                    PropertyChangeEvent?.Invoke(firstname);
                }
            }
        }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
