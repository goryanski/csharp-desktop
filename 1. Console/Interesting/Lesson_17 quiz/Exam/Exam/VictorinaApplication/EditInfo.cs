using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.AuthenticationHelper;
using Exam.Models;
using Exam.Storages;
using NLog;

namespace Exam.VictorinaApplication
{
    class EditInfo
    {
        UsersStorage usersStorage;
        AccountsStorage accountsStorage;
        RegistrationService registrationInfo;
        public string UserLogin { get; set; }

        public EditInfo()
        {
            usersStorage = UsersStorage.Instance;
            accountsStorage = AccountsStorage.Instance;
            registrationInfo = new RegistrationService();
            UserLogin = QuizApp.userLogin;         
        }

        public void ChangeBirth()
        {
            ShowDate();
            Console.Write("\nChange birth:");
            DateTime birth = registrationInfo.GetBirth();

            // создадим временный экземпляр класса UserInfo что бы воспользоваться готовым кодом для валидации
            UserInfo userInfo = new UserInfo { Birth = birth };
            var result = ObjectValidator.Validate(userInfo);
            if (!result.validated)
            {
                registrationInfo.ShowReasons(result);
                return;
            }
            
            // что бы поменять дату рождения там нужно найти пользователя в хранилище пользователей, для  этого получим id пользователя используя его логин (классы аккаунт и информация пользователя связаны по id)
            string id = GetID();

            // теперь по id найдем индекс пользователя
            int idx = usersStorage.Users.FindIndex(u => u.AccountId.Equals(id));

            // и изменим дату рождения в хранилище, что бы сразу созранить информацию в файл
            usersStorage.ChangeDate(idx, birth);
            Console.WriteLine("Date was changed");
        }

        public void ChangePassword()
        {
            ShowPassword();
            Console.Write("\nChange password:");
            string password = registrationInfo.GetPassword();

            Account account = new Account { Login = UserLogin, Password = password };
            var result = ObjectValidator.Validate(account);
            if (!result.validated)
            {
                registrationInfo.ShowReasons(result);
                return;
            }

            int idx = accountsStorage.Accounts.FindIndex(a => a.Login.Equals(UserLogin));
            accountsStorage.ChangePassword(idx, password);
            Console.WriteLine("Password was changed");
        }


        #region Вспомогательные методы
        string GetID()
        {
            // найдем индекс аккаунта с нужным логином
            int idx = accountsStorage.Accounts.FindIndex(a => a.Login.Equals(UserLogin));

            // и вернем id по этому индексу
            return accountsStorage.Accounts[idx].Id;
        }
        void ShowDate()
        {
            int idx = usersStorage.Users.FindIndex(u => u.AccountId.Equals(GetID()));
            Console.Write("\nYour birth is ");
            Console.WriteLine(usersStorage.Users[idx].Birth.ToShortDateString());
        }
        void ShowPassword()
        {
            int idx = accountsStorage.Accounts.FindIndex(a => a.Login.Equals(UserLogin));
            Console.Write("\nYour password is ");
            Console.WriteLine(accountsStorage.Accounts[idx].Password);
        }
        #endregion
    }
}
