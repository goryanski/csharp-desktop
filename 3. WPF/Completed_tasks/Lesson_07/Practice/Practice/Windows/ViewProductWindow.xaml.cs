using System;
using System.Collections.Generic;
using System.Linq;
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
using Practice.Controls;

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewProductForm.xaml
    /// </summary>
    public partial class ViewProductWindow : Window
    {
        public Product Item { get; set; }      
        public ViewProductWindow(Product product)
        {
            InitializeComponent();
            DataContext = this;
            Item = new Product();
            Item = product;
            
            Title = Item.Title;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
