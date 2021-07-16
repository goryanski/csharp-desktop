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

namespace Practice.Controls
{
    /// <summary>
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        const int STARS_COUNT = 10;
        List<string> emptyStars;
        List<string> yellowStars;

        public BindingList<string> RatingStars { get; set; }

        public Rating(int ratingValue)
        {
            InitializeComponent();
            InitializeStarsLists();
            SetRatingStars(ratingValue);
            DataContext = this;
        }

        private void SetRatingStars(int ratingValue)
        {
            
            RatingStars = new BindingList<string>();
            int i = 0;
            for (; i < ratingValue; i++)
            {
                RatingStars.Add(yellowStars[i]);
            }
            for (; i < STARS_COUNT; i++)
            {
                RatingStars.Add(emptyStars[i]);
            }
        }

        private void InitializeStarsLists()
        {
            emptyStars = new List<string>();
            yellowStars = new List<string>();
            for (int i = 0; i < STARS_COUNT; i++)
            {
                emptyStars.Add(@"..\Images\empty-star.png");
                yellowStars.Add(@"..\Images\yellow-star.png");
            }           
        }
    }
}
