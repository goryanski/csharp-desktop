using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.Controls;
using Practice.Helpers;
using Practice.Windows;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductsStorage productsStorage = ProductsStorage.Instance;
        public BindingList<Product> Products { get; set; }

        Product product = new Product();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Products = productsStorage.Products;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditWindow wnd = new EditWindow(EditWindow.Action.Add)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            if (wnd.ShowDialog() == true)
            {
                wnd.Item.CreatedDate = DateTime.Now;
                productsStorage.Products.Add(wnd.Item);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                Product selProduct = lbProducts.SelectedItem as Product;
                
                EditWindow wnd = new EditWindow(EditWindow.Action.Edit, selProduct.Clone() as Product)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                
                if (wnd.ShowDialog() == true)
                {
                    selProduct.Copy(wnd.Item);
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                Product selProduct = lbProducts.SelectedItem as Product;
                productsStorage.Products.Remove(selProduct);
            }
        }

        private void BtnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                ViewProductWindow wnd = new ViewProductWindow(lbProducts.SelectedItem as Product)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                wnd.ShowDialog();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            productsStorage.SaveToFile();
        }
    }
}
