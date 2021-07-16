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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductViewer.xaml
    /// </summary>
    public partial class ProductViewer : Window
    {
        public Product Product { get; set; }
        public ProductViewer(Product product)
        {
            InitializeComponent();
            DataContext = this;
            Product = new Product();
            Product = product;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
