using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Practice.Models.Helpers
{
    class TargetValidator
    {
        ToDoItem target = new ToDoItem();
        internal bool IsTargetValid(ToDoItem target, string priority, string date)
        {
            this.target = target;

            try
            {
                CheckName();
                // description валидироовать не будем, не всегда нужно его писать, да и имя тоже, но минимально можно
                CheckPriority(priority);
                CheckDateEnd(date);
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CheckDateEnd(string date)
        {
            try
            {
                target.DateEnd = Convert.ToDateTime(date);
                if (target.DateEnd < DateTime.Now)
                {
                    throw new InvalidDataException("Date cant'be earlier than date now");
                }
            }
            catch(FormatException)
            {
                throw new InvalidDataException("Incorrect date format");
            }        
        }

        private void CheckPriority(string priority)
        {
            if (!Regex.IsMatch(priority, "^[0-5]{1}$"))
            {
                throw new InvalidDataException("Incorrect entered priority." +
                    "\nmust be value 0-5, only gigits");
            }          
        }
        private void CheckName()
        {
            if (target.Name == string.Empty)
            {
                throw new InvalidDataException("Name field can't be epmty");
            }
        }  
    }
}
