using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Models;
using Exam.Models.Helpers;

namespace Exam.forms
{
    public partial class AuthenticationForm : Form
    {       
        public enum Action
        {
            Login,
            Registration
        }

        Action action;
        UsersStorage usersStorage = UsersStorage.Instance;
        UserValidator validator = new UserValidator();
        public User Person { get; set; } = new User();
        
        public AuthenticationForm(Action action)
        {
            InitializeComponent();
            this.action = action;
            SetTitle();
        }

        private void SetTitle()
        {
            switch (action)
            {
                case Action.Login:
                    Text = "Login";
                    break;
                case Action.Registration:
                    Text = "Registration";
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            FillPerson();
            if (validator.IsUserValid(Person))
            {
                // после валидации данных пройдем еще несколько проверок для регистрации или входа
                if(action == Action.Login)
                {
                    if (usersStorage.UserExist(Person))
                    {
                        if (!usersStorage.IsPasswordCorrect(Person))
                        {
                            MessageBox.Show("Wrong password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (action == Action.Registration)
                {
                    if (usersStorage.UserExist(Person))
                    {
                        MessageBox.Show("User already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    usersStorage.Users.Add(Person);
                }

                // и если все в порядке, то мы или добавим нового юзера при регистрации или войдем - в любом случае операция завершится успехом 
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FillPerson()
        {
            Person.Login = tbLogin.Text;
            Person.Password = tbPassword.Text;
        }
    }
}
