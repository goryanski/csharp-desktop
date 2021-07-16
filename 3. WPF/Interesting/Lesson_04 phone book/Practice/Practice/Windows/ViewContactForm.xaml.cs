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
using Practice.Models;

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewContactForm.xaml
    /// </summary>
    public partial class ViewContactForm : Window
    {
        public Contact Person { get; set; }

        public ViewContactForm(Contact contact)
        {
            InitializeComponent();
            DataContext = this;
            Person = new Contact();
            Person = contact;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
