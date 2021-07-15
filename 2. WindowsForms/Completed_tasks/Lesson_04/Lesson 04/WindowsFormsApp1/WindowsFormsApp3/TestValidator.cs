using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.Models
{
    class TestValidator
    {
        internal void CheckEditFields(string testNmae, string question, string answer)
        {         
            try
            {
                TestNameValidation(testNmae);
                TextValidation(question, answer);
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TextValidation(string question, string answer)
        {
            if(question.Length < 4 || question.Length > 128)
            {
                throw new InvalidDataException("Incorrect entered question." +
                    "\nmust be 4-128 symbols"); 
            }
            if (answer.Length < 1 || answer.Length > 16)
            {
                throw new InvalidDataException("Incorrect entered answer." +
                    "\nmust be 1-16 symbols");
            }
        }

        private void TestNameValidation(string testNmae)
        {
            if(!Regex.IsMatch(testNmae, "^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9 ]{3,24}$"))
            {
                throw new InvalidDataException("Incorrect entered test name." +
                    "\nmust be 4-24 symbols, first a letter, only letters and digits");
            }
        }
    }
}
