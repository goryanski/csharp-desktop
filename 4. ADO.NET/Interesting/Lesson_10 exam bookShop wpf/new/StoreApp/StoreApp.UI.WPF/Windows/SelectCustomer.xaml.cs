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
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectCustomer.xaml
    /// </summary>
    public partial class SelectCustomer : Window
    {
        public List<CustomerDTO> Customers { get; set; } = new List<CustomerDTO>();
        public CustomerDTO SelectedCustomer { get; set; } = new CustomerDTO();

        public SelectCustomer(List<CustomerDTO> customers)
        {
            InitializeComponent();
            DataContext = this;

            Customers = customers;           
        }

        private void BbtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            SelectedCustomer = cbCustomers.SelectedItem as CustomerDTO;

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
