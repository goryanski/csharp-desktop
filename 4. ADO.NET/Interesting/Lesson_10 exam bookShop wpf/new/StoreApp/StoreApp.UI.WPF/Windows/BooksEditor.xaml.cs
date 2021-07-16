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
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для BooksEditor.xaml
    /// </summary>
    public partial class BooksEditor : Window
    {
        public enum Action
        {
            Edit,
            Add
        }

        public Action Act { get; set; }
        public BookDTO Book { get; set; } = new BookDTO();
        public string PublishingOffice { get; set; }
        public int SelectedBookId{ get; set; }
        public List<string> AuthorsList { get; set; } = new List<string>();

        BooksEditorDbService dbService = new BooksEditorDbService();

        public BooksEditor(Action action, int id = 0)
        {
            InitializeComponent();
            DataContext = this;
          
            FieldsInit(action, id);
            RunAction();
        }

        private void FieldsInit(Action action, int id)
        {
            Act = action;

            if(Act == Action.Edit)
            {
                SelectedBookId = id;
                Book = dbService.GetFullBookInfo(id);
                PublishingOffice = Book.PublishingOffice.Name;
                foreach (var Author in Book.Authors)
                {
                    AuthorsList.Add(Author.FullName);
                }

                if (Book.IsSequel)
                {
                    chbIsSequel.IsChecked = true;
                }
            }           
        }

        private void RunAction()
        {
            switch (Act)
            {
                case Action.Edit:
                    Title = "Form of redaction";
                    break;
                case Action.Add:
                    Title = "Form of addition";
                    break;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            BookModelValidation book = new BookModelValidation
            {
                Name = tbName.Text,
                Pages = tbPages.Text,
                Genre = tbGenre.Text,
                Discount = tbDiscount.Text,
                PublishYear = tbPublishYear.Text,
                AmountInStorage = tbAmountInStorage.Text,
                PublishingOffice = tbPublishingOffice.Text,
                Author1 = tbAuthor1.Text,
                Author2 = tbAuthor2.Text,
                Author3 = tbAuthor3.Text,
                Author4 = tbAuthor4.Text,
                Author5 = tbAuthor5.Text
            };
            


            // для валидации денег, если будет с запятой, но если введут бред то TryParse вернет 0
            string primeCost = tbPrimeCost.Text;
            primeCost = primeCost.Replace('.', ',');
            decimal newPrimeCost;
            decimal.TryParse(primeCost, out newPrimeCost);
            book.PrimeCost = newPrimeCost;

            string price = tbPrice.Text;
            price = price.Replace('.', ',');
            decimal newPrice;
            decimal.TryParse(price, out newPrice);
            book.Price = newPrice;



            if (new BookValidator().IsBookValid(book))
            {
                book.IsSequel = chbIsSequel.IsChecked == true;

                if (Act == Action.Add)
                {
                    Book = dbService.CreateBook(book);
                }
                else if (Act == Action.Edit)
                {
                    // добавим Id выбранной из списка книги что бы знать какую обновлять
                    book.Id = SelectedBookId;
                    Book = dbService.UpdateBook(book);
                }

                DialogResult = true;
                Close();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
