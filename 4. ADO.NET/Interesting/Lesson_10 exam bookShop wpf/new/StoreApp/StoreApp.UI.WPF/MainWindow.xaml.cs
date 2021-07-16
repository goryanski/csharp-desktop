using StoreApp.BLL.DTO;
using StoreApp.BLL.Services;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories;
using StoreApp.UI.WPF.DbServices;
using StoreApp.UI.WPF.Extensions;
using StoreApp.UI.WPF.Helpers;
using StoreApp.UI.WPF.Windows;
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

namespace StoreApp.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
            Инициализация по умолчанию в UnitOfWork
            В папке DbServices собранны классы для работы с БД, что бы отделить логику работы с базой от графического интерфейса. Каждый класс соответствует своему окну, к которому он предоставляет методы по работе с БД
            В классе ServicesStorage собранны все сервисы, к которым есть доступ только в классах из папки DbServices
         */

        MainDbService dbService = new MainDbService();
        public ObservableCollection<BookDTO> Books { get; set; } = new ObservableCollection<BookDTO>();

        string defaultSearchText = "find by name, genre or author...";


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            this.Loaded += MainWindow_Loaded;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;           
        }

        #region loading
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnAdd.Visibility = btnEditMode.Visibility = btnSell.Visibility = btnDelete.Visibility = Visibility.Hidden;
            this.Title = "BookShop";

            LoadAllBooks();
            SetDefaultSearchText();            
        }

        private void SetDefaultSearchText()
        {
            tbxSearch.Text = defaultSearchText;
            tbxSearch.Foreground = Brushes.Gray;
            tbNotFound.Visibility = Visibility.Hidden;
        }

        private void LoadAllBooks()
        {
            var books = dbService.GetExistsBooks();
            Books.AddRange(books);
            
        }

        #endregion


        #region Right buttons panel
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Authentication wnd = new Authentication(Authentication.Action.Login)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                btnAdd.Visibility = btnEditMode.Visibility = btnSell.Visibility = btnDelete.Visibility = Visibility.Visible;
                btnLogin.Visibility = btnRegistration.Visibility = Visibility.Hidden;
                this.Title = "BookShop seller mode";
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Authentication wnd = new Authentication(Authentication.Action.Registration)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            wnd.ShowDialog();
        }

        private void BtnSell_Click(object sender, RoutedEventArgs e)
        {
            if (lbBooks.SelectedIndex != -1)
            {
                BookDTO book = lbBooks.SelectedItem as BookDTO;
                if (book.AmountInStorage > 0)
                {
                    dbService.SellBook(book.Id);
                    book.AmountInStorage--;

                    MessageBox.Show($"The book is sold, take the money: {book.Price} - {book.Discount}% discount", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Books are over", ":(", MessageBoxButton.OK, MessageBoxImage.Warning);
                }   
            }
            else
            {
                MessageBox.Show($"Select book first", "Not selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbBooks.SelectedIndex != -1)
            {
                BookDTO book = lbBooks.SelectedItem as BookDTO;
                dbService.RemoveBook(book.Id);
                Books.Remove(book);
            }
            else
            {
                MessageBox.Show($"Select book first", "Not selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            BooksEditor wnd = new BooksEditor(BooksEditor.Action.Add)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                // так сделать не получится Books.Add(wnd.Book) , у нас нет id в wnd.Book, при добавлении мы его не указываем, оно появится только после того как книга добавится в базу, а ее одну достать из базы тоже не можем потому что не знаем ее id - значит перезагружаем листбокс
                ReloadListBox();
            }
        }

        private void BtnEditMode_Click(object sender, RoutedEventArgs e)
        {
            if (lbBooks.SelectedIndex != -1)
            {
                BookDTO book = lbBooks.SelectedItem as BookDTO;
                
                EditMode wnd = new EditMode(book)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                wnd.ShowDialog();
                // поскольку в окне EditMode случиться может что угодно, просто обновим ObservableCollection что бы избежать множества проверок
                ReloadListBox();
            }               
            else
            {
                MessageBox.Show($"Select book first", "Not selected",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }
        #endregion


        #region Filter buttons panel
        private void BtnNewBooksFilter_Click(object sender, RoutedEventArgs e)
        {
            Books.Clear();
            Books.AddRange(dbService.GeTNewestBooks());
            
            if(Books.Count == 0) tbNotFound.Visibility = Visibility.Visible;
        }

        private void BtnNewBooksFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            tbNotFound.Visibility = Visibility.Hidden;
        }

        private void BtnPopularBooksFilter_Click(object sender, RoutedEventArgs e)
        {
            Books.Clear();
            Books.AddRange(dbService.GeTMostPopularBooks());

            if (Books.Count == 0) tbNotFound.Visibility = Visibility.Visible;
        }

        private void BtnPopularBooks_LostFocus(object sender, RoutedEventArgs e)
        {
            tbNotFound.Visibility = Visibility.Hidden;
        }

        private void BtnPopularAuthors_Click(object sender, RoutedEventArgs e)
        {
            var authors = dbService.GeTMostPopularAuthors();
            PopularityView wnd = new PopularityView(PopularityView.Action.ShowAuthors, authors)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            wnd.ShowDialog();
        }

        private void BtnGenresFilter_Click(object sender, RoutedEventArgs e)
        {
            Filter wnd = new Filter(Filter.Action.FilterGenres)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };
            if (wnd.ShowDialog() == true)
            {
                var genres = dbService.GeTMostPopularBooks(wnd.Duration);

                PopularityView viewWnd = new PopularityView(PopularityView.Action.ShowGenres, genres)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                viewWnd.ShowDialog();
            }
        } 
        #endregion


        #region Search panel
        private void TbxSearch_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxSearch.Text = string.Empty;
        }

        private void TbxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            SetDefaultSearchText();
        }

        private void BtnClearAllFilters_Click(object sender, RoutedEventArgs e)
        {
            ReloadListBox();
        }

        private void TbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbxSearch.Text.Equals(string.Empty) ||
                tbxSearch.Text.Equals(defaultSearchText))
            {
                ReloadListBox();
                tbNotFound.Visibility = Visibility.Hidden;
            }
            else
            {
                Books.Clear();
                tbNotFound.Visibility = Visibility.Hidden;

                var suitableBooks = dbService.FindSearchMatches(tbxSearch.Text);

                if (suitableBooks.Count > 0)
                {
                    Books.AddRange(suitableBooks);
                }
                else
                {
                    tbNotFound.Visibility = Visibility.Visible;
                }
            }            
        }
        #endregion


        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbBooks.SelectedIndex != -1)
            {
                BookDTO book = lbBooks.SelectedItem as BookDTO;
                ViewBook wnd = new ViewBook(book)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                wnd.ShowDialog();
            }
        }
        private void ReloadListBox()
        {
            Books.Clear();
            LoadAllBooks();
        }
    }
}
