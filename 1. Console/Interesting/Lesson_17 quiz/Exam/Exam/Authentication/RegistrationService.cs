using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exam.Models;
using Exam.Storages;
using NLog;

namespace Exam.AuthenticationHelper
{
    class RegistrationService
    {
        readonly Logger logger;
        UsersStorage usersStorage;
        AccountsStorage accountsStorage;
        public RegistrationService()
        {
            logger = LogManager.GetCurrentClassLogger();
            usersStorage = UsersStorage.Instance;
            accountsStorage = AccountsStorage.Instance;
        }

        public void Registration()
        {
            Account account = FillAccount();
            var result = ObjectValidator.Validate(account);
            if (!result.validated)
            {
                ShowReasons(result);
                return;
            }

            UserInfo userInfo = FillUserInfo(account.Id);
            result = ObjectValidator.Validate(userInfo);
            if (!result.validated)
            {
                ShowReasons(result);
                return;
            }

            // Сохранять объекты будем только после того как оба объекта пройдут валидацию, нельзя допустить, что бы в хранилище записался только один из объектов, поскольку они связаны через id

            // так же нужно еще проверить, не существует ли уже пользователь, которого хотим добавить. сделаем это по логину
            if (!accountsStorage.AddAccount(account)) // если не получилось добавить
            {
                Console.WriteLine("Try again...");
            }
            else
            {
                // если такого пользователя нет, то account добавился, добавим и userInfo
                usersStorage.AddUser(userInfo);
                Console.WriteLine("\nRegistration complete");
            }                      
        }


        #region Вспомогательные методы
        public void ShowReasons((List<string> errors, bool validated) result)
        {
            foreach (var item in result.errors)
            {
                logger.Info(item);
            }

            logger.Error("Registration failed");
            Console.WriteLine("Try again...");
        }
        Account FillAccount()
        {
            string login = GetLogin();
            string password = GetPassword();
            return new Account { Login = login, Password = password };
        }
        UserInfo FillUserInfo(string id)
        {
            string name = GetName();
            DateTime birth = GetBirth();
            return new UserInfo { Name = name, Birth = birth, AccountId = id };
        }
        string GetName()
        {
            Console.WriteLine("\nName must be 4-16 symbols, start with a letter, may contain numbers and _");
            Console.Write("Enter name: ");
            return Console.ReadLine();
        }
        public DateTime GetBirth()
        {
            Console.WriteLine("\nDate must be like this template: year-month-day(2020-04-25)");
            Console.WriteLine("Обязательно с '-', год должен быть 4-х значным числом а месяц и день, если меньше 10, то должен быть записан c нулем (например 01)");
            Console.Write("Your date: ");
            string date = Console.ReadLine();

            DateTime birth = new DateTime();
            if (Regex.IsMatch(date, @"^[0-9]{4}\-[0-9]{2}\-[0-9]{2}$"))
            {
                // если даже дата совпадет с регулярным выражением, то к примеру дата 2000-12-35 существовать не может и если попытаемся присвоить такую дату DateTime, викинет исключение System.FormatException, его то мы и словим. Таким образом, из этого метода мы вернем или корректную дату или пустую дату, которая не пройдет дальнейшую валидацию 
                try
                {
                    birth = DateTime.Parse(date);
                    return birth;
                }
                catch (System.FormatException)
                {
                    logger.Info("This date can't exist");
                }
            }
            else
            {
                logger.Info("Date entered incorrectly");              
            }
            return birth;
        }
        string GetLogin()
        {
            Console.WriteLine("\nLogin must be 4-16 symbols, start with a letter, may contain numbers and symbol _");
            Console.Write("Enter login: ");
            return Console.ReadLine();
        }
        public string GetPassword()
        {
            Console.WriteLine("\nPassword must be 4-16 symbols, may contain numbers and symbol _");
            Console.Write("Enter password: ");
            return Console.ReadLine();
        }
        #endregion
    }
}
