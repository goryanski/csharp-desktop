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
using Practice.Models;
using Practice.Models.Helpers;
using Practice.Windows;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleStorage peopleStorage = PeopleStorage.Instance;
        public BindingList<Contact> Contacts { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Contacts = peopleStorage.People;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditWindow wnd = new EditWindow(EditWindow.Action.Add)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                peopleStorage.People.Add(wnd.Person);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lbContacts.SelectedIndex != -1)
            {
                Contact selPerson = lbContacts.SelectedItem as Contact;
                EditWindow wnd = new EditWindow(EditWindow.Action.Edit, selPerson.Clone() as Contact)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                
                if (wnd.ShowDialog() == true)
                {
                    selPerson.Copy(wnd.Person);
                }
            }      
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbContacts.SelectedIndex != -1)
            {
                Contact selPerson = lbContacts.SelectedItem as Contact;
                peopleStorage.People.Remove(selPerson);
            }
        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (lbContacts.SelectedIndex != -1)
            {
                Contact selPerson = lbContacts.SelectedItem as Contact;
                ViewContactForm wnd = new ViewContactForm(selPerson)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                wnd.ShowDialog();
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            peopleStorage.SaveToFile();
        }   
    }
}
