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
    class ContactValidator
    {
        Contact contact = new Contact();

        internal bool IsContactValid(Contact contact)
        {
            this.contact = contact;

            try
            {
                CheckName();
                CheckPhone();
                CheckAddress();
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CheckName()
        {
            string checkExpression = "^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я]{1,15}$";
            if (!Regex.IsMatch(contact.FirstName, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered first name." +
                    "\nmust be 2-16 symbols, only letters");
            }
            if (!Regex.IsMatch(contact.LastName, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered last name." +
                    "\nmust be 2-16 symbols, only letters");
            }
        }
        private void CheckPhone()
        {
            if (!Regex.IsMatch(contact.PhoneNumber, "^[+?0-9][0-9]{9,12}$"))
            {
                throw new InvalidDataException("Incorrect entered phone number." +
                    "\nmust be 10-13 symbols, only gigits, symbol + in front of number is also allowed");
            }
        }
        private void CheckAddress()
        {
            if (contact.Address.Length < 4 || contact.Address.Length > 32)
            {
                throw new InvalidDataException("Incorrect entered address." +
                    "\nmust be 4-32 symbols");
            }
        }
    }
}
