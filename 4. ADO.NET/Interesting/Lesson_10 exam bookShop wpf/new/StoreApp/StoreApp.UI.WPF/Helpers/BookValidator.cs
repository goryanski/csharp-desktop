using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using StoreApp.BLL.DTO;

namespace StoreApp.UI.WPF.Helpers
{
    public class BookValidator
    {
        public BookModelValidation Book { get; set; } = new BookModelValidation();

        internal bool IsBookValid(BookModelValidation book)
        {
            Book = book;

            try
            {
                CheckYear();
                CheckRest();
                return true;
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }



        private void CheckYear()
        {
            int year;
            int.TryParse(Book.PublishYear, out year);
            if (year < 1200 || year > DateTime.Now.Year)
            {
                throw new InvalidDataException("Incorrect entered Publish Year." +
                    "\nmust be 1200-Now value, only gigits");
            }
        }


        private void CheckRest()
        {
            if (!Regex.IsMatch(Book.Name, "^[a-zA-Z][a-zA-Z0-9 ]{2,29}$"))
            {
                throw new InvalidDataException("Incorrect entered book name." +
                    "\nmust be 3-30 symbols, English language, first a letter, only letters, gigits, spaces");
            }
            if (!Regex.IsMatch(Book.Pages, "^[1-9][0-9]{1,3}$"))
            {
                throw new InvalidDataException("Incorrect entered book pages." +
                    "\nmust be 10-9999 pages, only gigits, first not zero");
            }
            if (!Regex.IsMatch(Book.Genre, "^[a-zA-Z][a-zA-Z ]{2,29}$"))
            {
                throw new InvalidDataException("Incorrect entered book genre." +
                    "\nmust be 3-30 symbols, English language, only letters, spaces");
            }
            if (Book.PrimeCost <= 0)
            {
                throw new InvalidDataException("Incorrect entered Prime Cost.");
            }
            if (Book.Price <= 0)
            {
                throw new InvalidDataException("Incorrect entered Price.");
            }
            if (!Regex.IsMatch(Book.Discount, "^[0-9]{1,2}$"))
            {
                throw new InvalidDataException("Incorrect entered Discount." +
                    "\nmust be 0-99 value, only gigits");
            }
            if (!Regex.IsMatch(Book.AmountInStorage, "^[1-9][0-9]{0,1}$"))
            {
                throw new InvalidDataException("Incorrect entered Amount In Storage." +
                    "\nmust be 1-99 value, only gigits");
            }
            if (!Regex.IsMatch(Book.PublishingOffice, "^[a-zA-Z][a-zA-Z0-9 ]{2,29}$"))
            {
                throw new InvalidDataException("Incorrect entered Publishing Office." +
                    "\nmust be 3-30 symbols, English language, first a letter, only letters, gigits, spaces");
            }
            if (!Regex.IsMatch(Book.Author1, "^[a-zA-Z][a-zA-Z ]{2,50}$"))
            {
                throw new InvalidDataException("Incorrect entered Author #1." +
                    "\nmust be 3-51 symbols, English language, only letters, spaces");
            }
            if(Book.Author2 != string.Empty)
            {
                if (!Regex.IsMatch(Book.Author2, "^[a-zA-Z][a-zA-Z ]{2,50}$"))
                {
                    throw new InvalidDataException("Incorrect entered Author #2." +
                        "\nmust be 3-51 symbols, English language, only letters, spaces OR empty field");
                }
            }
            if (Book.Author3 != string.Empty)
            {
                if (!Regex.IsMatch(Book.Author3, "^[a-zA-Z][a-zA-Z ]{2,50}$"))
                {
                    throw new InvalidDataException("Incorrect entered Author #3." +
                        "\nmust be 3-51 symbols, English language, only letters, spaces OR empty field");
                }
            }
            if (Book.Author4 != string.Empty)
            {
                if (!Regex.IsMatch(Book.Author4, "^[a-zA-Z][a-zA-Z ]{2,50}$"))
                {
                    throw new InvalidDataException("Incorrect entered book Author #4." +
                        "\nmust be 3-51 symbols, English language, only letters, spaces OR empty field");
                }
            }
            if (Book.Author5 != string.Empty)
            {
                if (!Regex.IsMatch(Book.Author5, "^[a-zA-Z][a-zA-Z ]{2,50}$"))
                {
                    throw new InvalidDataException("Incorrect entered book Author #5." +
                        "\nmust be 3-51 symbols, English language, only letters, spaces OR empty field");
                }
            }          
        }
    }

}
