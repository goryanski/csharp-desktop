using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
using WpfApp1.Models.Database.Repository;
using WpfApp1.Models.Extensions;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        UnitOfWork db = UnitOfWork.Instance;    

        public Category Category { get; set; }

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductsWindow(Category category)
        {
            InitializeComponent();
            DataContext = this;
            Category = new Category();
            Category = category;
            this.Loaded += ProductsWindow_Loaded;
        }

        private void ProductsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void UpdateProducts()
        {
            Products.Clear();
            var products = db.ProductsRepository.GetProductsByCategory(Category.Id);
            Products.AddRange(products);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductEditor wnd = new ProductEditor(ProductEditor.Action.Add)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                Product product = wnd.Product;
                db.ProductsRepository.Create(product);               
                db.Save();
                // что бы сразу обновилось в приложении
                if (wnd.Product.CategoryId == Category.Id)
                {
                    Products.Add(product);
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                Product selProduct = lbProducts.SelectedItem as Product;
                ProductEditor wnd = new ProductEditor(ProductEditor.Action.Edit, selProduct.Clone() as Product)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };

                if (wnd.ShowDialog() == true)
                {
                    selProduct.Copy(wnd.Product);
                    db.Save();
                    // поскольку содной категорию продукта при редактировании можем поменять на другую внутри категории, что бы изменения отобразились сразу на экране поможет только полное обновление списка продуктов
                    UpdateProducts();
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                Product selProduct = lbProducts.SelectedItem as Product;
                db.ProductsRepository.Remove(selProduct.Id);
                Products.Remove(selProduct);
                db.Save();               
            }
        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                Product selProduct = lbProducts.SelectedItem as Product;
                ProductViewer wnd = new ProductViewer(selProduct)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                wnd.ShowDialog();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
