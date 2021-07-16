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

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для GenresFilter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        public enum Action
        {
            FilterGenres,
            FilterDiscount
        }

        public Action Act { get; set; }

        public int Duration { get; set; }
        public int Discount { get; set; }
        public Filter(Action action)
        {
            InitializeComponent();
            this.Act = action;
            SetTitle();
        }

        private void SetTitle()
        {
            switch (Act)
            {
                case Action.FilterDiscount:
                    ActionForFilterDiscount();
                    break;
                case Action.FilterGenres:
                    ActionForFilterGenres();
                    break;
            }
        }

        private void ActionForFilterDiscount()
        {
            this.Title = "Choose discount";
            rbFirst.Content = "Spring (10%)";
            rbSecond.Content = "Summer (25%)";
            rbThird.Content = "Autumn (40%)";
            rbFourth.Content = "Winter (60%)";
        }

        private void ActionForFilterGenres()
        {
            this.Title = "Choose duration";
            rbFirst.Content = "Day";
            rbSecond.Content = "Week";
            rbThird.Content = "Month";
            rbFourth.Content = "Year";
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(Act == Action.FilterGenres)
            {
                if (rbFirst.IsChecked == true) Duration = 1;
                if (rbSecond.IsChecked == true) Duration = 7;
                if (rbThird.IsChecked == true) Duration = 30;
                if (rbFourth.IsChecked == true) Duration = 365;
            }
            else if(Act == Action.FilterDiscount)
            {
                if (rbFirst.IsChecked == true) Discount = 10;
                if (rbSecond.IsChecked == true) Discount = 25;
                if (rbThird.IsChecked == true) Discount = 40;
                if (rbFourth.IsChecked == true) Discount = 60;
            }

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
