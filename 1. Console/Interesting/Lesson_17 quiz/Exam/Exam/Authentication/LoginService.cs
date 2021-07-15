using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;
using Exam.Storages;
using Exam.TestManagementUtility;
using NLog;

namespace Exam.Authentication
{
    class LoginService
    {
        readonly Logger logger;
        AccountsStorage accountsStorage;
        PathsStorage pathsStorage;
        public LoginService()
        {
            logger = LogManager.GetCurrentClassLogger();
            accountsStorage = AccountsStorage.Instance;
            pathsStorage = PathsStorage.Instance;
        }

        public void Login()
        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Account adminAccount = GetAdminData();
            
            if(login.Equals(adminAccount.Login) && password.Equals(adminAccount.Password))
            {
                new UtilityApplication().Start();
            }
            else
            {
                try
                {
                    // что бы знать, что именно было не правильно введено при входе в систему, проверяем не все сразу, а по очереди
                    var srchAccount  = accountsStorage.Accounts.First(acc => acc.Login == login);
                    if (srchAccount.Password.Equals(password))
                    {
                        new QuizApp().Start(login);
                    }
                    else
                    {
                        logger.Warn("Wrong password");
                    }
                }
                catch (InvalidOperationException)
                {
                    logger.Warn("User not found");
                }
            }
        }


        Account GetAdminData()
        {
            if (File.Exists(pathsStorage.ADMIN_PATH))
            {
                string login;
                string password;

                using (StreamReader reader = new StreamReader(new FileStream(pathsStorage.ADMIN_PATH, FileMode.Open, FileAccess.Read)))
                {
                    login = reader.ReadLine();
                    password = reader.ReadLine();
                }

                return new Account { Login = login, Password = password, Id = "1" };
            }
            else
            {
                logger.Error("No admin data file"); // Error выводит информацию только в файл
                // если файла с данными админа не окажется на месте(кто-то его случайно удалит или переместит), то что бы не крашнулась програма - вернем резервный логин и пароль админа. таким образом, если админ не сможет зайти в систему под своим паролем, он зайдет в журнал логов, прочитает, что файла админа нет и добавит его с таким логином и паролем, который ему нужен, или, если ему нужно срочно получить доступ - зайдет под этим резервным паролем
                return new Account { Login = "admin", Password = "admin", Id = "1" };
            }          
        }
    }
}
