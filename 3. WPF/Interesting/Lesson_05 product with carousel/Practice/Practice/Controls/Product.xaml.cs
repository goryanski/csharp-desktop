using System;
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

namespace Practice.Controls
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : UserControl//, INotifyPropertyChanged
    {
        // добавляем карусель 
        // по изменению названия папки будем обновлять картинки в карусель, которые находятся в этой папке
        private string _imagesCategory = string.Empty;
        public string ImagesFolder
        {
            get => _imagesCategory;
            set
            {
                if (!_imagesCategory.Equals(value))
                {
                    _imagesCategory = value;
                    OnImagesFolderChanged(ImagesFolder);
                }
            }
        }
        private void OnImagesFolderChanged(string propertyName)
        {
            string imagesPath = @"..\..\Images\";
            string fullImagesPath = System.IO.Path.GetFullPath(imagesPath + propertyName);
           
            List<string> images = new List<string>();
            try
            {
                images = Directory.GetFiles(fullImagesPath).ToList();

                if (images.Count < 1)
                {
                    // если картинок нет, воспользуемся тем же самым исключением для удобства, поскольку все равно никаких сообщений не передаем
                    throw new DirectoryNotFoundException();
                }
            }
            catch (DirectoryNotFoundException)
            {
                images.Add(System.IO.Path.GetFullPath(imagesPath + "no_image.jpg"));               
            }

            spCarousels.Children.Add(new Carousel(images));
        }




        // добавляем рейтинг
        // так же при изменении свойства Rating будем менять соотношение звоздочек. проинициализируем _rating не очевидным числом, но главное не 0, а то если пользователь выставит рейтинг 0, то массив не проинициализируется, т.к. не произойдет изменение свойства Rating
        private int _rating = -1000;
        public int Rating
        {
            get => _rating;
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnRatingChanged(Rating);
                }
            }
        }
        private void OnRatingChanged(int ratingValue)
        {
            if (ratingValue < 0) ratingValue = 0;
            if (ratingValue > 10) ratingValue = 10;

            spRating.Children.Add(new Rating(ratingValue));
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }

        public Product()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
