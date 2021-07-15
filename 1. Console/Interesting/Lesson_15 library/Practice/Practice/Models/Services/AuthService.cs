using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Practice.Models.Services
{
    class AuthService
    {
        public Account Account { get; set; }
        readonly Logger logger;

        public AuthService() => logger = LogManager.GetCurrentClassLogger();

        public void Registration()
        {
            Account acc = FillAccount();

            var result = ObjectValidator.Validate(acc);
            if (!result.validated)
            {
                foreach (var item in result.errors)
                {
                    logger.Warn(item);
                }

                logger.Error("Registration failed");
                Console.WriteLine("Try again...");
            }
            else
            {
                Account = acc;
                Console.WriteLine("Registration complete");
            }
        }

        public void Login()
        {
            if (Account == null)
            {
                Console.WriteLine("You must check in first");
                return;
            }

            string login = GetLogin();
            string password = GetPassword();

            int flag = 0;
            if (!login.Equals(Account.Login))
            {
                logger.Warn("Wrong login.");
                flag = 1;
            }
            if (!password.Equals(Account.Password))
            {
                logger.Warn("Wrong password.");
                flag = 1;
            }
            if (flag == 1)
            {
                logger.Error("Login failed");
                Console.WriteLine("Try again...");
                return;
            }

            new UserPanel().Start();
        }

        Account FillAccount()
        {
            string login = GetLogin();
            string password = GetPassword();

            Account acc = new Account { Login = login, Password = password };
            return acc;
        }

        string GetLogin()
        {
            Console.Write("Enter Login: ");
            return Console.ReadLine();
        }
        string GetPassword()
        {
            Console.Write("Enter Password: ");
            return Console.ReadLine();
        }
    }
}
