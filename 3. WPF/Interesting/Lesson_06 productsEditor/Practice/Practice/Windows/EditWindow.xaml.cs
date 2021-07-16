using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Practice.Controls;
using Practice.Helpers;

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public enum Action
        {
            Edit,
            Add
        }

        public Product Item { get; set; }
        string defaultImagePath;
        ProductValidator validator = new ProductValidator();
        public string NativeImage { get; set; }

        public EditWindow(Action action, Product product = null)
        {
            InitializeComponent();
            DataContext = this;
            InitializeFields(product);
            RunAction(action);         
        }

        #region Load Form
        private void InitializeFields(Product product)
        {
            if (product is null)
            {
                Item = new Product();
            }
            else
            {
                Item = product;
                NativeImage = Item.Picture;
            }

            defaultImagePath = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(ImageSaveHelper.UPLOAD, "no-photo.png"));
        }

        private void RunAction(Action action)
        {
            switch (action)
            {
                case Action.Edit:
                    ActionsForEdit();
                    break;
                case Action.Add:
                    ActionsForAdd();
                    break;
            }
        }

        private void ActionsForEdit()
        {
            Title = "Form of product redaction";
            ImagePlace.Tag = Item.Picture;
        }

        private void ActionsForAdd()
        {
            SetDefaultImage();
            ImagePlace.Tag = defaultImagePath;
            Title = "Form of product addition";
        }

        private void SetDefaultImage()
        {
            ImagePlace.Source = new BitmapImage(new Uri(defaultImagePath));
        }
        #endregion


        #region Buttons click
        private void BtnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Images(.png,.jpg,.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dlg.ShowDialog() == true)
            {
                string newPath = System.IO.Path.GetFullPath(ImageSaveHelper.Save(dlg.FileName));
                ImagePlace.Source = new BitmapImage(new Uri(newPath));
                ImagePlace.Tag = newPath;
                tbImagePath.Text = newPath;
            }
        }

        private void BtnClearPathField_Click(object sender, RoutedEventArgs e)
        {
            tbImagePath.Text = string.Empty;
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            if (tbImagePath.Text != string.Empty)
            {
                WebClient wc = new WebClient();
                string filename = System.IO.Path.GetFileName(tbImagePath.Text);
                string extension = System.IO.Path.GetExtension(filename);
                filename = $"{Guid.NewGuid()}{extension}";

                try
                {
                    string savePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(ImageSaveHelper.UPLOAD, filename));
                    wc.DownloadFile(tbImagePath.Text, savePath);
                    ImagePlace.Source = new BitmapImage(new Uri(savePath));
                    ImagePlace.Tag = savePath;
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Item.Title = tbTitle.Text;
            string price = tbPrice.Text;
            Item.Description = tbDescription.Text;
            Item.Seller = tbSeller.Text;
            Item.Category = tbCategory.Text;
            Item.Picture = ImagePlace.Tag.ToString();
            string rating = tbRating.Text;

            if (validator.IsProductValid(Item, price, rating))
            {
                Item.Price = Convert.ToDecimal(price);
                Item.Rating = int.Parse(rating);
                DialogResult = true;
                Close();
            }
        }
        #endregion

        private void CbNoPicture_Checked(object sender, RoutedEventArgs e)
        {
            SetDefaultImage();
            tbImagePath.Text = string.Empty;
            tbImagePath.IsEnabled = false;
            btnAddImage.IsEnabled = false;
            btnOpenImage.IsEnabled = false;
            ImagePlace.Tag = defaultImagePath;
        }

        private void CbNoPicture_Unchecked(object sender, RoutedEventArgs e)
        {
            tbImagePath.IsEnabled = true;
            btnAddImage.IsEnabled = true;
            btnOpenImage.IsEnabled = true;
        }
    }
}
