using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models.Database.Models;
using WpfApp1.Models.Helpers;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для CategoryEditor.xaml
    /// </summary>
    public partial class CategoryEditor : Window
    {
        public string CategoryName { get; set; }

        public CategoryEditor(string categoryName = null)
        {
            InitializeComponent();
            DataContext = this;
            CategoryName = categoryName ?? string.Empty;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;

            if (new Validator().IsValid(name))
            {
                CategoryName = name;
                DialogResult = true;
                Close();
            }
        }
    }
}
