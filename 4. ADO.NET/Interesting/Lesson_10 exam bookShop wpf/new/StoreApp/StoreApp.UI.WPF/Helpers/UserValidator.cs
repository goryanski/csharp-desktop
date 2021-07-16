using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.UI.WPF.Helpers
{
    public class UserValidator
    {
        SellerDTO seller = new SellerDTO();

        internal bool IsUserValid(SellerDTO seller)
        {
            this.seller = seller;

            try
            {
                CheckLogin();
                CheckPassword();
                return true;
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        private void CheckLogin()
        {
            if (!Regex.IsMatch(seller.Login, "^[a-zA-Z][a-zA-Z0-9_]{3,12}$"))
            {
                throw new InvalidDataException("Incorrect entered login." +
                    "\nmust be 4-12 symbols, first a letter, only letters, digits, and symbol _");
            }
        }
        private void CheckPassword()
        {
            if (!Regex.IsMatch(seller.Password, "^[a-zA-Z0-9_]{4,12}$"))
            {
                throw new InvalidDataException("Incorrect entered password." +
                    "\nmust be 4-12 symbols, only letters, digits, and symbol _");
            }
        }
    }
}
