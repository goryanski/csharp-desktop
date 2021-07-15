using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice.Models;

namespace Practice
{
    public partial class Form : System.Windows.Forms.Form
    {
        EditCarForm editCarForm;
        ViewForm viewCarForm;
        CarsStorage carsStorage;
        public Form()
        {
            InitializeComponent();         
            carsStorage = CarsStorage.Instance;
            LoadCarsToForm();
        }

        private void LoadCarsToForm()
        {
            lbChooseCar.DataSource = carsStorage.Cars;
        }

        private void ChooseAction_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (lbChooseCar.SelectedIndex != -1)
            {
                Car selectedCar = lbChooseCar.SelectedItem as Car;

                switch (button.Name)
                {
                    case "btnAddCar":
                        RunAddCarForm();
                        break;
                    case "btnEditCar":
                        RunEditCarForm(selectedCar);
                        break;
                    case "btnViewCar":
                        RunViewCarForm(selectedCar);
                        break;
                    case "btnDeleteCar":
                        DeleteSelectedCar(selectedCar);
                        break;
                }
            }         
        }

        private void RunAddCarForm()
        {
            editCarForm = new EditCarForm()
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            if (editCarForm.ShowDialog() == DialogResult.OK)
            {
                carsStorage.Cars.Add(editCarForm.AdditedCar);
                ReloadCarsList();
            }
        }
        private void RunEditCarForm(Car selectedCar)
        {
            editCarForm = new EditCarForm(selectedCar.Clone() as Car)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            if (editCarForm.ShowDialog() == DialogResult.OK)
            {
                selectedCar.Copy(editCarForm.EditCar);
                ReloadCarsList();
            }
        }

        private void RunViewCarForm(Car selectedCar)
        {
            viewCarForm = new ViewForm(selectedCar)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };
            viewCarForm.ShowDialog();
        }


        private void DeleteSelectedCar(Car selectedCar)
        {
            carsStorage.Cars.Remove(selectedCar);
            ReloadCarsList();
        }


        private void ReloadCarsList()
        {
            lbChooseCar.DataSource = null;
            lbChooseCar.DataSource = carsStorage.Cars;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            carsStorage.SaveToFile();
        }
    }
}
