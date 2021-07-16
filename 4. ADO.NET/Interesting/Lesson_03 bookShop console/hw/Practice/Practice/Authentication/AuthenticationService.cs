using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.App;
using Practice.App.helpers;
using Practice.Entities;
using Practice.Repository;

namespace Practice.Authentication
{
    public class AuthenticationService
    {
        Validator validator = new Validator();
        PeopleRepository peopleRepository = new PeopleRepository(new DbHelper().GetContext());
        AccountsRepository accountsRepository = new AccountsRepository(new DbHelper().GetContext());

        public void Registration()
        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();

            Account foundAccount = accountsRepository.Get(a => a.Login == login);
            if (foundAccount != null)
            {
                Console.WriteLine("User already exists. Try again");
                return;
            }

            Console.Write("Enter passvord: ");
            string password = Console.ReadLine();
            Console.Write("Enter firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter lastname: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter birth (YY-MM-DD): ");
            DateTime birth = validator.SafelyInput(new DateTime());


            // зарегистрируем пользователя не используя готовую процедуру
            Account account = new Account
            {
                Login = login,
                Password = password,
                RegistrationDate = DateTime.Now
            };

            accountsRepository.Create(account);
            foundAccount = accountsRepository.Get(a => a.Login == login);

            Person person = new Person
            {
                FirstName = firstname,
                LastName = lastname,
                Birth = birth,
                AccountId = foundAccount.Id
            };

            peopleRepository.Create(person);
            Console.WriteLine("Registration success");
        }

        public void Login()
        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();
            Console.Write("Enter passvord: ");
            string passvord = Console.ReadLine();


            Account foundAccount = accountsRepository.Get(a => a.Login == login);
            if (foundAccount != null)
            {
                if(foundAccount.Password == passvord)
                {
                    new BookShopApp().Start();
                }
                else
                {
                    Console.WriteLine("Wrong password. Try again");
                }
                
            }
            else
            {
                Console.WriteLine("User not found. Try again");
            }
        }
    }
}
