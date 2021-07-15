using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice.Models;

namespace Practice.Validation
{
    class CarValidator
    {
        Car car = new Car();

        internal bool IsCarValid(Car additedCar, string price)
        {
            car = additedCar;

            try
            {
                CheckPrice(price);
                CheckColorAndCountry();
                CheckModelAndMark();
                return true;
            }
            // неверно введены данные 
            catch (InvalidDataException ex)
            {             
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        private void CheckPrice(string price)
        {
            if (!Regex.IsMatch(price, "^[1-9][0-9]{3,10}$"))
            {
                throw new InvalidDataException("Incorrect entered price." +
                    "\nmust be 4-10 symbols, first not zero, only digits, no dots");
            }
        }
        private void CheckColorAndCountry()
        {
            string checkExpression = "[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я ]{1,24}$";
            if (!Regex.IsMatch(car.Color, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered color." +
                    "\nmust be 2-24 symbols, only letters");
            }
            if (!Regex.IsMatch(car.Country, checkExpression))
            {
                throw new InvalidDataException("Incorrect entered country." +
                    "\nmust be 2-24 symbols, only letters");
            }
        }     
        private void CheckModelAndMark()
        {
            if (car.Mark.Length < 2 || car.Mark.Length > 12)
            {
                throw new InvalidDataException("Incorrect entered mark." +
                    "\nmust be 2-12 symbols");
            }
            if (car.Model.Length < 2 || car.Model.Length > 12)
            {
                throw new InvalidDataException("Incorrect entered model." +
                    "\nmust be 2-12 symbols");
            }
        }
    }
}
