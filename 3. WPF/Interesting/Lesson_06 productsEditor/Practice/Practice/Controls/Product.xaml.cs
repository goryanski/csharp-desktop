using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Practice.Helpers;
using Practice.Windows;

namespace Practice.Controls
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : UserControl, INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title = string.Empty;
        private decimal _price = 0;
        private string _description = string.Empty;
        private string _seller = string.Empty;
        private string _category = string.Empty;
        private DateTime _createdDate = DateTime.MinValue;
        private string _picture = string.Empty;
        private int _rating = 0;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (!_description.Equals(value))
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public string Seller
        {
            get => _seller;
            set
            {
                if (!_seller.Equals(value))
                {
                    _seller = value;
                    OnPropertyChanged(nameof(Seller));
                }
            }
        }
        public string Category
        {
            get => _category;
            set
            {
                if (!_category.Equals(value))
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        public DateTime CreatedDate
        {
            get => _createdDate;
            set
            {
                if (_createdDate != value)
                {
                    _createdDate = value;
                    OnPropertyChanged(nameof(CreatedDate));
                }
            }
        }
        public string Picture
        {
            get => _picture;
            set
            {
                if (!_picture.Equals(value))
                {
                    _picture = value;
                    OnPropertyChanged(nameof(Picture));
                }
            }
        }
        public int Rating
        {
            get => _rating;
            set
            {
                ;
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));                  
                    CreateRatingStars(Rating);
                }
            }
        }
        private void CreateRatingStars(int ratingValue)
        {
            // по скольку изменение свойства происходит перед валидайией, то проверим здесь значение для того что бы все корректно отработало, а потом еще раз проверим в классе-валидаторе но уже только для того что бы уведомить пользователя что он вписал некорректное значение
            if (ratingValue < 0) ratingValue = 0;
            if (ratingValue > 10) ratingValue = 10;

            RatingStars.Clear();
            const int STARS_COUNT = 10;
            List<string> emptyStars = new List<string>();
            List<string> yellowStars = new List<string>();

            for (int j = 0; j < STARS_COUNT; j++)
            {
                emptyStars.Add(@"..\Images\empty-star.png");
                yellowStars.Add(@"..\Images\yellow-star.png");
            }
            

            int i = 0;
            for (; i < ratingValue; i++)
            {
                RatingStars.Add(yellowStars[i]);
            }
            for (; i < STARS_COUNT; i++)
            {
                RatingStars.Add(emptyStars[i]);
            }

            // теперь RatingStars заполнен нужными звездами и можно к нему биндиться
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BindingList<string> RatingStars { get; set; } = new BindingList<string>();


        public Product()
        {
            InitializeComponent();        
            Width = 220;
            Height = 320;
        }

        public object Clone()
        {
            Product product = new Product();
            product.Copy(this);
            return product;
        }

        public void Copy(Product from)
        {
            Title = from.Title;
            Price = from.Price;
            Description = from.Description;
            Seller = from.Seller;
            Category = from.Category;
            CreatedDate = from.CreatedDate;
            Picture = from.Picture;
            Rating = from.Rating;
        }

        public void Copy(SavedProduct from)
        {
            Title = from.Title;
            Price = from.Price;
            Description = from.Description;
            Seller = from.Seller;
            Category = from.Category;
            CreatedDate = from.CreatedDate;
            Picture = from.Picture;
            Rating = from.Rating;
        }
    }
}
