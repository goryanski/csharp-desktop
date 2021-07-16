using System;
using System.Collections.Generic;
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

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calc calc;

        const string SCREEN_DEFAULT_TEXT = "0";
        public bool IsOperationPressed { get; set; }
        public bool IsSimpleVersion { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            calc = new Calc();
            IsOperationPressed = false;
            IsSimpleVersion = true;
            screen.Text = SCREEN_DEFAULT_TEXT;
        }

        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Equals(SCREEN_DEFAULT_TEXT) || IsOperationPressed)
            {
                screen.Text = "";
            }

            IsOperationPressed = false;
            Button btn = sender as Button;

            if (btn.Content.ToString() == "," && screen.Text == "")
            {
                screen.Text = $"{SCREEN_DEFAULT_TEXT}{btn.Content.ToString()}";
            }
            else if ((btn.Content.ToString() == "," && !screen.Text.Contains(",")) || btn.Content.ToString() != ",")
            {
                screen.Text += btn.Content.ToString();
            }
        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (IsSimpleVersion)
            {
                calc.Operation = btn.Content.ToString();
                calc.Result = double.Parse(screen.Text);
                IsOperationPressed = true;
                memory.Content = $"{calc.Result} {calc.Operation}";
                IsSimpleVersion = false;
            }
            else
            {
                if (!IsOperationPressed)
                {
                    screen.Text = calc.Calculate(screen.Text);
                    calc.Operation = btn.Content.ToString();
                    calc.Result = double.Parse(screen.Text);
                    IsOperationPressed = true;
                    memory.Content = $"{calc.Result} {calc.Operation}";
                }
            }
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            memory.Content = "";
            screen.Text = calc.Calculate(screen.Text);
            IsSimpleVersion = true;
        }

        private void ButtonClearLast_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Length == 1 && screen.Text != SCREEN_DEFAULT_TEXT)
            {
                screen.Text = SCREEN_DEFAULT_TEXT;
            }
            else if (screen.Text != SCREEN_DEFAULT_TEXT)
            {
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
            }
        }

        private void ButtonClearScreen_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = SCREEN_DEFAULT_TEXT;
        }

        private void ButtonClearAll_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = SCREEN_DEFAULT_TEXT;
            calc.Result = 0;
            memory.Content = "";
            IsSimpleVersion = true;
            IsOperationPressed = false;
        }
    }
}
