using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using WpfApp1.Models.Database.Models;

namespace WpfApp1.Models.Helpers
{
    public class Validator
    {
        internal bool IsValid(string name, decimal price = -1, Category category = null)
        {         
            try
            {
                CheckName(name);
                if(category != null)
                {
                    CheckPrice(price);
                    CheckCategory(category);
                }            
                return true;
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CheckCategory(Category category)
        {
            if(category is null)
            {
                throw new InvalidDataException("Category is not selected");
            }
        }

        private void CheckName(string name)
        {
            if (!Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9 ]{2,29}$"))
            {
                throw new InvalidDataException("Incorrect entered name." +
                    "\nmust be 3-30 symbols, English language, first a letter, only letters, gigits, spaces");
            }
        }
        private void CheckPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new InvalidDataException("Incorrect entered price.");
            }
        }
    }
}
