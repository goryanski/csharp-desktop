﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.Models.Helpers
{
    class UserValidator
    {
        User user = new User();

        internal bool IsUserValid(User user)
        {
            this.user = user;

            try
            {
                CheckLogin();
                CheckPassword();
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void CheckLogin()
        {
            if (!Regex.IsMatch(user.Login, "^[a-zA-Z][a-zA-Z0-9_]{3,12}$"))
            {
                throw new InvalidDataException("Incorrect entered login." +
                    "\nmust be 4-12 symbols, first a letter, only letters, digits, and symbol _");
            }
        }
        private void CheckPassword()
        {
            if (!Regex.IsMatch(user.Password, "^[a-zA-Z0-9_]{4,12}$"))
            {
                throw new InvalidDataException("Incorrect entered password." +
                    "\nmust be 4-12 symbols, only letters, digits, and symbol _");
            }
        }      
    }
}
