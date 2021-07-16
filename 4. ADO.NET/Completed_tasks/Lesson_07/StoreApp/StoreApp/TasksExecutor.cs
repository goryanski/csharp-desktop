using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;

namespace StoreApp.UI.Console
{
    public class TasksExecutor : BaseTasksHelper
    {

        // тестирование методов в сервисах

        public void Task_1_CreateDefaultUser() // создаем 1 человека в базе
        {
            usersService.CreateUser(new UserDto
            {
                FirstName = "Maks",
                LasttName = "Ivanov",
                IsBlocked = false
            });
            ordersService.CreateOrder(new OrderDto
            {
                Date = DateTime.Now,
                OrderSum = 555,
                UserId = 1
            });
            
            System.Console.Write(usersService.GetUserById(1));
            System.Console.WriteLine(" was created");
        }


        public void Task_2_FindUsersByName() 
        {
            string name = "Maks";
            var srchUsers = usersService.GetUsersByName(name);
            int count = 0;

            System.Console.WriteLine($"List of people with name '{name}':");
            srchUsers.ForEach(user =>
            {
                System.Console.WriteLine($"[{++count}] {user}");
            });

            if (count == 0)
            {
                System.Console.WriteLine("Users not found");
            }
        }


        public void Task_3_BlockSelectedUser() 
        {
            var user = GetSelectedEntity(usersService.GetAllUsers());
            if (user != null)
            {
                usersService.BlockUser(user.Id);

                System.Console.Write(usersService.GetUserById(1));
                System.Console.WriteLine(" was blocked");
            }
        }


        public void Task_4_MakeOrderForUser()
        {
            var customer = GetSelectedEntity(usersService.GetAllUsers());
            if (customer != null)
            {
                System.Console.WriteLine("Enter sum: ");
                decimal sum;
                decimal.TryParse(System.Console.ReadLine(), out sum);

                ordersService.MakeOrder(sum, customer.Id);
                System.Console.WriteLine("Order added.");

                ShowEntitiesList<OrderDto>(usersService.GetUserById(customer.Id).Orders);
            }
        }


        public void Task_5_ShowOrdersSelectedUser()
        {
            // нет смысла сздавать для этого новый метод в ordersService, поскольку у нас есть usersService.GetAllUsers() с Include, воспользуемся им 
            var srchUser = GetSelectedEntity(usersService.GetAllUsers());
            ShowEntitiesList<OrderDto>(srchUser.Orders);
        }


        public void Task_6_ShowOrdersByRange()
        {
            DateTime from = new DateTime(2019, 03, 03);
            DateTime to = DateTime.Now;
            System.Console.WriteLine($"All orders from {from.ToShortDateString()} to {to.ToShortDateString()}");
            var ordersRange = ordersService.GetRangeByDate(from, to);
            ShowEntitiesList<OrderDto>(ordersRange);
        }
    }
}
