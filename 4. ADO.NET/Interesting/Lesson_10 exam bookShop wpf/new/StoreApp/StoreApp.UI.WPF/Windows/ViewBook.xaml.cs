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
    /// Логика взаимодействия для ViewBook.xaml
    /// </summary>
    public partial class ViewBook : Window
    {
        public BookDTO Book { get; set; }
        public string IsSequel { get; set; }
        public string AuthorsList { get; set; }
        public string PublishingOffice { get; set; }



        public ViewBook(BookDTO book)
        {
            InitializeComponent();

            DataContext = this;
            Book = new BookDTO();
            Book = book;

            FieldsInit();          
        }


        private void FieldsInit()
        {
            IsSequel = Book.IsSequel ? "Is sequel" : "Is not sequel";

            foreach (var Author in Book.Authors)
            {
                AuthorsList += $"{Author}\n";
            }

            PublishingOffice = new ViewBookDbService()
                .GetPublishingOfficeName(Book.PublishingOfficeId);
        }



        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
