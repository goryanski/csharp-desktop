using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.Models.Helpers
{
    class PhotoValidator
    {
        Photo photo = new Photo();

        internal bool IsPhotoValid(Photo user)
        {
            photo = user;

            try
            {
                CheckNameAndCaregory();
                CheckDescription();
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void CheckNameAndCaregory()
        {        
            string checkExpression = "^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9_ ]{3,18}$";
            if (!Regex.IsMatch(photo.PhotoName, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered photo name." +
                    "\nmust be 4-18 symbols, first a letter, only letters and numbers. Spaces and _ symbol are also allowed. And photo name must be without extension.");
            }
            if (!Regex.IsMatch(photo.PhotoCategory, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered photo category." +
                    "\nmust be 4-18 symbols, first a letter, only letters and numbers. Spaces and _ symbol are also allowed");
            }
        }
        private void CheckDescription()
        {
            if (photo.PhotoDescription.Length < 2 || photo.PhotoDescription.Length > 512)
            {
                throw new InvalidDataException("Incorrect entered photo description." +
                    "\nmust be 2-512 symbols");
            }
        }
    }
}
