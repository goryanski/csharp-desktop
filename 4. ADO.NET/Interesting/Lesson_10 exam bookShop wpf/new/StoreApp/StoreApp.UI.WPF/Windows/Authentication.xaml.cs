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
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.UI.WPF.DbServices;
using StoreApp.UI.WPF.Helpers;

namespace StoreApp.UI.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public enum Action
        {
            Login,
            Registration
        }
        public Action Act { get; set; }

        public Authentication(Action action)
        {
            InitializeComponent();

            this.Act = action;
            SetTitle();
        }

        private void SetTitle()
        {
            switch (Act)
            {
                case Action.Login:
                    this.Title = "Login";
                    break;
                case Action.Registration:
                    this.Title = "Registration";
                    break;
            }
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            SellerDTO seller = new SellerDTO
            {
                Login = tbxLogin.Text,
                Password = pbxPassword.Password
            };

            AuthenticationDbService dbService = new AuthenticationDbService();

            if (Act == Action.Registration)
            {              
                if(new UserValidator().IsUserValid(seller))
                {
                    if (dbService.UserExist(seller))
                    {
                        MessageBox.Show("User already exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    dbService.CreateUser(seller);
                    MessageBox.Show("Registration complete", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if(Act == Action.Login)
            {
                if (dbService.UserExist(seller))
                {
                    if (!dbService.IsPasswordCorrect(seller))
                    {
                        MessageBox.Show("Wrong password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // если сюда дойдем, то мы или добавим нового юзера при регистрации или войдем - в любом случае операция завершится успехом            
            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
