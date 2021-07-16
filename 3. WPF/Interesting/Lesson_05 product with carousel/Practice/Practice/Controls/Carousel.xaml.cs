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
    /// Логика взаимодействия для CarouselControl.xaml
    /// </summary>
    public partial class Carousel : UserControl, INotifyPropertyChanged
    {

        private string _currImgUrl = string.Empty;
        public string CurrentImageUrl
        {
            get => _currImgUrl;
            set
            {
                _currImgUrl = value;
                OnPropertyChanged(nameof(CurrentImageUrl));
            }
        }
        List<string> images;
        int currIdx = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Carousel(List<string> images)
        {
            InitializeComponent();
            DataContext = this;
            this.images = images;
            CurrentImageUrl = images[0];
        }       

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            currIdx--;
            if (currIdx < 0)
            {
                currIdx = images.Count - 1;
            }
            CurrentImageUrl = images[currIdx];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            currIdx++;
            if(currIdx > images.Count - 1)
            {
                currIdx = 0;
            }
            CurrentImageUrl = images[currIdx];
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
