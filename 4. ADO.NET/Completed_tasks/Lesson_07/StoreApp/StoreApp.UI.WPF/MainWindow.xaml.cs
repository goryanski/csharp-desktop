﻿using StoreApp.BLL.Services;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreApp.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IUnitOfWork uow = new UnitOfWork(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=storeAppDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            CategoriesService categoriesService = new CategoriesService(uow);
            ProductsService productsService = new ProductsService(uow);

            var categories = categoriesService.GetAllCategories();
            ;
        }
    }
}
