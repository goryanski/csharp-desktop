using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticeEditor.DataBase.Entities;

namespace PracticeEditor.Helpers
{
    public class Validator
    {
        internal bool IsUserValid(string name, string age)
        {
            try
            {
                CheckName(name);
                CheckAge(age);
                return true;
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void CheckName(string name)
        {
            if (!Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z0-9 ]{2,29}$"))
            {
                throw new InvalidDataException("Incorrect entered user name." +
                    "\nmust be 3-30 symbols, English language, first a letter, only letters, gigits, spaces");
            }
        }

        private void CheckAge(string age)
        {
            int ageInt;
            int.TryParse(age, out ageInt);
            if(ageInt < 12 || ageInt > 130)
            {
                throw new InvalidDataException("Incorrect entered user age." +
                    "\nmust be 12-130 value");
            }
        }
    }
}
