using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Models.Database;
using WpfApp1.Models.Database.Models;
using WpfApp1.Models.Database.Repository;
using WpfApp1.Models.Extensions;
using WpfApp1.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOfWork db = UnitOfWork.Instance;

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public MainWindow()
        {
            InitializeComponent();

            #region Init by default
            //var cat1 = new Category { Name = "food" };
            //var cat2 = new Category { Name = "Clothes" };

            //var prod1 = new Product
            //{
            //    Name = "Milk",
            //    Price = 25.5m,
            //    Category = cat1
            //};
            //var prod2 = new Product
            //{
            //    Name = "Bread",
            //    Price = 15,
            //    Category = cat1
            //};
            //var prod3 = new Product
            //{
            //    Name = "Shirt",
            //    Price = 350,
            //    Category = cat2
            //};

            //db.ProductsRepository.Create(prod1);
            //db.ProductsRepository.Create(prod2);
            //db.ProductsRepository.Create(prod3);

            //db.Save();

            //var categories = db.CategoriesRepository.GetAll();
            #endregion

            DataContext = this;

            this.Loaded += MainWindow_Loaded;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (lbCategories.SelectedIndex != -1)
            {
                Category selCategory = lbCategories.SelectedItem as Category;
                ProductsWindow wnd = new ProductsWindow(selCategory)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                wnd.ShowDialog();
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = db.CategoriesRepository.GetAll();
            Categories.AddRange(categories);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            CategoryEditor wnd = new CategoryEditor()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                Category category = new Category { Name = wnd.CategoryName };
                Categories.Add(category);
                db.CategoriesRepository.Create(category);
                db.Save();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lbCategories.SelectedIndex != -1)
            {
                Category selCategory = lbCategories.SelectedItem as Category;
                CategoryEditor wnd = new CategoryEditor(selCategory.Name)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                if (wnd.ShowDialog() == true)
                {
                    selCategory.Name = wnd.CategoryName;                   
                    db.Save();
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbCategories.SelectedIndex != -1)
            {                
                Category selCategory = lbCategories.SelectedItem as Category;

                // удалим вручную продукты этой категории 
                List<Product> products = db.ProductsRepository.GetAll(p => p.CategoryId == selCategory.Id);
                foreach (var product in products)
                {
                    db.ProductsRepository.Remove(product.Id);

                }
                db.Save();
                db.CategoriesRepository.Remove(selCategory.Id);
                Categories.Remove(selCategory);
                db.Save();
            }
        }
    }
}
