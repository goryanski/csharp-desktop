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
using StoreApp.BLL.DTO;
using StoreApp.UI.WPF.DbServices;

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditMode.xaml
    /// </summary>
    public partial class EditMode : Window
    {
        public BookDTO Book { get; set; }
        EditModeDbService dbService = new EditModeDbService();

        public EditMode(BookDTO book)
        {
            InitializeComponent();

            Book = book;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEditFields_Click(object sender, RoutedEventArgs e)
        {
           BooksEditor wnd = new BooksEditor(BooksEditor.Action.Edit, Book.Id)
           {
               WindowStartupLocation = WindowStartupLocation.CenterOwner,
               Owner = this
           };
            wnd.ShowDialog();

            //  После изменения книги внутри окна BooksEditor обновим и книгу внутри этого окна, что бы здесь была постоянно "актуальная информация" пока мы работаем с этим окном. это же касается и остальных событий по клику, все что изменяем сохраняем в Book
            Book = wnd.Book;
        }

        private void BtnSetDiscount_Click(object sender, RoutedEventArgs e)
        {
            Filter wnd = new Filter(Filter.Action.FilterDiscount)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                dbService.SetDiscount(Book.Id, wnd.Discount);
                Book.Discount = wnd.Discount;
            }           
        }

        private void BtnWriteOff_Click(object sender, RoutedEventArgs e)
        {
            ;
            if(Book.AmountInStorage > 0)
            {
                dbService.WriteOffBook(Book.Id);
                Book.AmountInStorage--;

                MessageBox.Show($"One book is written off from the stock", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("You can't write off book if there're no one in stock", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnSetAside_Click(object sender, RoutedEventArgs e)
        {
            if (Book.AmountInStorage > 0)
            {
                var customers = dbService.GetCustomers();
                SelectCustomer wnd = new SelectCustomer(customers)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };

                if(wnd.ShowDialog() == true)
                {
                    dbService.SetBookAside(Book.Id, wnd.SelectedCustomer.Id);
                    Book.AmountInStorage--;

                    MessageBox.Show($"One book is set aside from the stock", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("You can't set aside book if there're no one in stock", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
