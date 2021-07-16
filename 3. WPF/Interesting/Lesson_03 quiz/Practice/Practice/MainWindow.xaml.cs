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
using Practice.Models;
using Practice.Models.Helpers;
using Practice.Windows;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserValidator validator = new UserValidator();
        UsersStorage usersStorage = UsersStorage.Instance;
        ResultsStorage resultsStorage = ResultsStorage.Instance;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Login = tbLogin.Text,
                Password = tbPassword.Text
            };

            if (validator.IsUserValid(user))
            {
                if (usersStorage.UserExist(user))
                {
                    if (!usersStorage.IsPasswordCorrect(user))
                    {
                        MessageBox.Show($"Wrong password for login {user.Login}", "Warning",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    // ok
                }
                else
                {
                    if (cbRememberMe.IsChecked == true)
                    {
                        usersStorage.Users.Add(user);
                    }
                    else
                    {
                        // если пользователь не поставил галочку, то при выходе из окна викторины ему нужно будет снова вводить логин и палоль. а у существующих пользователей (которые поставили галочку) - логин и пароль останутся в поле ввода
                        tbLogin.Text = string.Empty;
                        tbPassword.Text = string.Empty;
                    }
                }

                QuizWindow quiz = new QuizWindow(user.Login)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };
                quiz.ShowDialog();
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            usersStorage.SaveToFile();
            resultsStorage.SaveToFile();
        }
    }
}
