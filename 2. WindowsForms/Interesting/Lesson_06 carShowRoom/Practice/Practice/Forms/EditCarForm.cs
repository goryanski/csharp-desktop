using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice.Models;
using Practice.Models.Helpers;
using Practice.Validation;

namespace Practice
{
    public partial class EditCarForm : System.Windows.Forms.Form
    {
        CarValidator validator;
        string defaultImagePath;

        public Car AdditedCar { get; }
        public Car EditCar { get; }

        bool isAdditionCar;
        bool isRedactionCar;

        // конструктор без параметров - запускает форму добавления машины
        public EditCarForm()
        {
            InitializeComponent();
            isAdditionCar = true;
            isRedactionCar = false;
            AdditedCar = new Car();
        }

        // конструктор с параметром - запускает форму редактирования машины
        public EditCarForm(Car car)
        {
            InitializeComponent();
            isAdditionCar = false;
            isRedactionCar = true;
            EditCar = car;
            LoadCarToForm();          
        }


        private void EditCarForm_Load(object sender, EventArgs e)
        {
            validator = new CarValidator();

            defaultImagePath = Path.Combine(ImageSaveHelper.UPLOAD, "default_car.jpeg");

            if (isAdditionCar)
            {
                SetDefaultImage();
                // запишем в свойство Tag путь к картинке по умолчанию что бы его потом от сюда получать при сохранении 
                pbImage.Tag = defaultImagePath;

                Text = "Form of addition car";
            }         

            if (isRedactionCar) Text = "Form of redaction car";
        }

        // только для редактирования используется
        private void LoadCarToForm()
        {
            tbMark.Text = EditCar.Mark;
            tbModel.Text = EditCar.Model;
            tbPrice.Text = EditCar.Price.ToString();
            tbColor.Text = EditCar.Color;
            tbCountry.Text = EditCar.Country;
            tbImagePath.Text = EditCar.PicturePath;

            pbImage.Image = Image.FromFile(EditCar.PicturePath);
            pbImage.Tag = EditCar.PicturePath;
        }

        private void SetDefaultImage()
        {
            pbImage.Image = Image.FromFile(defaultImagePath);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            if(tbImagePath.Text != "")
            {
                WebClient wc = new WebClient();
                string filename = Path.GetFileName(tbImagePath.Text);
                string extension = Path.GetExtension(filename);
                filename = $"{Guid.NewGuid().ToString()}{extension}";

                string savePath = Path.Combine(ImageSaveHelper.UPLOAD, filename);

                try
                {
                    wc.DownloadFile(tbImagePath.Text, savePath);
                    pbImage.Image = Image.FromFile(savePath);
                    // запишем в свойство Tag наш путь что бы его потом от сюда получать при сохранении 
                    pbImage.Tag = savePath;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Wrong path. Check entered path.\nMore details:\n" + ex.Message);
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Wrong path. Check entered path.\nMore details:\n" + ex.Message);
                }
            }
        }

        private void BtnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Images(.png,.jpg,.jpeg)|*.png;*.jpg;*.jpeg"
            };

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                string newPath = ImageSaveHelper.Save(dlg.FileName);
                pbImage.Image = Image.FromFile(newPath);          
                pbImage.Tag = newPath;
            }
        }

        private void BtnClearPathField_Click(object sender, EventArgs e)
        {
            tbImagePath.Text = "";
        }

        private void CbNoPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoPicture.Checked)
            {
                SetDefaultImage();
                tbImagePath.Text = "";
                pbImage.Tag = defaultImagePath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (isAdditionCar)
            {
                //будем сначала присваивать значения с текстбоксов экземпляру класса, а потом уже этот экземпляр валидировать, что бы не мучаться с большим кол-вом параметров
                FillAdditedCar();
                //поскольку Price в поле класса типа decimal, то если мы сейчас попытаемся преобразовать в децемал введенную пользователем строку, то валидировать уже может быть поздно после этого.
                // по этому создадим временную строку и провалидируем ее, если валидация пройдет успешно, то преобразуем ее значение в поле класса
                string tmpPrice = tbPrice.Text;

                if (validator.IsCarValid(AdditedCar, tmpPrice))
                {
                    AdditedCar.Price = Convert.ToDecimal(tmpPrice);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }

            else if (isRedactionCar)
            {
                RewriteEditCar();
                string tmpPrice = tbPrice.Text;

                if (validator.IsCarValid(EditCar, tmpPrice))
                {
                    EditCar.Price = Convert.ToDecimal(tmpPrice);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void FillAdditedCar()
        {
            AdditedCar.Mark = tbMark.Text;
            AdditedCar.Model = tbModel.Text;

            // запишем в поле класса уже окончательно выбранное изображение 
            AdditedCar.PicturePath = pbImage.Tag.ToString();

            AdditedCar.Color = tbColor.Text;
            AdditedCar.Country = tbCountry.Text;
        }

        private void RewriteEditCar()
        {
            EditCar.Mark = tbMark.Text;
            EditCar.Model = tbModel.Text;
            EditCar.Color = tbColor.Text;
            EditCar.Country = tbCountry.Text;
            EditCar.PicturePath = pbImage.Tag.ToString();
        }
    }
}