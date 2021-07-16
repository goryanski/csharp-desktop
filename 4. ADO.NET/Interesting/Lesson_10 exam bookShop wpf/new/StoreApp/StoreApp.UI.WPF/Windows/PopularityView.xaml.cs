using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для PopularityView.xaml
    /// </summary>
    public partial class PopularityView : Window
    {
        public enum Action
        {
            ShowAuthors,
            ShowGenres
        }

        public Action Act { get; set; }

        public string Info { get; set; } 
        public PopularityView(Action action, string info)
        {
            InitializeComponent();

            DataContext = this;
            this.Act = action;
            Info = info;
            SetTitle();

            if (Info.Equals(string.Empty))
            {
                Info = "There're no popular\ngenres for this period";
            }
        }

        private void SetTitle()
        {
            switch (Act)
            {
                case Action.ShowAuthors:
                    this.Title = "Most popular authors";
                    break;
                case Action.ShowGenres:
                    this.Title = "Most popular genres";
                    break;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
