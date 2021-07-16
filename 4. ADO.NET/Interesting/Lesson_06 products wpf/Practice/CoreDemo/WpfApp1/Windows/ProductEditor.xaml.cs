using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Models.Helpers;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductEditor.xaml
    /// </summary>
    public partial class ProductEditor : Window
    {
        public enum Action
        {
            Edit,
            Add
        }

        UnitOfWork db = UnitOfWork.Instance;
        public Product Product { get; set; }
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();


        public ProductEditor(Action action, Product product = null)
        {
            InitializeComponent();
            DataContext = this;

            //Product = (product is null) ? new Product() : product;
            Product = product ?? new Product();           
            this.Loaded += ProductEditor_Loaded;
            RunAction(action);
        }

        private void ProductEditor_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = db.CategoriesRepository.GetAll();
            Categories.AddRange(categories);
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

        private void ActionsForAdd()
        {
            Title = "Form of addition";
        }

        private void ActionsForEdit()
        {
            Title = "Form of redaction";
        }

      
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;

            string price = tbPrice.Text;
            price = price.Replace('.', ',');
            decimal newPrice;
            decimal.TryParse(price, out newPrice);

            Category category = cbCategories.SelectedItem as Category;

            if (new Validator().IsValid(name, newPrice, category))
            {
                Product.Name = name;              
                Product.Price = newPrice;              
                Product.Category = category;
                
                DialogResult = true;
                Close();
            }           
        }
    }
}
