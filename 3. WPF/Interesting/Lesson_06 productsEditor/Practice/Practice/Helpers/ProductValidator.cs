using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Practice.Controls;

namespace Practice.Helpers
{
    class ProductValidator
    {
        Product product = new Product();
        internal bool IsProductValid(Product product, string price, string rating)
        {
            this.product = product;

            try
            {
                CheckTitle();
                CheckPrice(price);
                CheckDescription();
                CheckSellerAndCategory();
                CheckRating(rating);
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CheckTitle()
        {
            if (!Regex.IsMatch(product.Title, "^[a-zA-Z][a-zA-Z0-9 ]{3,29}$"))
            {
                throw new InvalidDataException("Incorrect entered title." +
                    "\nmust be 4-30 symbols, English language, first a letter, only letters, gigits, spaces");
            }
        }
        private void CheckPrice(string price)
        {
            if (!Regex.IsMatch(price, "^[1-9][0-9]{0,4}$"))
            {
                throw new InvalidDataException("Incorrect entered price." +
                    "\nmust be value 1-10000, only gigits, first not a zero");
            }
        }
        private void CheckDescription()
        {
            if (product.Description.Length < 4 || product.Description.Length > 512)
            {
                throw new InvalidDataException("Incorrect entered description." +
                    "\nmust be 4-512 symbols");
            }
        }

        private void CheckSellerAndCategory()
        {
            string checkExpression = "^[a-zA-Z][a-zA-Z ]{2,18}$";
            if (!Regex.IsMatch(product.Seller, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered seller name." +
                    "\nmust be 2-18 symbols, English language, only letters, spaces");
            }
            if (!Regex.IsMatch(product.Category, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered category." +
                    "\nmust be 2-18 symbols, English language, only letters, spaces");
            }
        }

        private void CheckRating(string rating)
        {           
            if (Regex.IsMatch(rating, "^[0-9]{1,2}$"))
            {
                int tmp = int.Parse(rating);
                if(tmp <= 10)
                {
                    // 0-10
                    return;
                }
            }
            throw new InvalidDataException("Incorrect entered rating." +
                    "\nmust be value 0-10, only gigits");
        }
    }
}
