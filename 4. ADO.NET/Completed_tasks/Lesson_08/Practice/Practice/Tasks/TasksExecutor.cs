using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.BLL.DTO;

namespace Practice.Tasks
{
    public class TasksExecutor : BaseTasksHelper
    {

        // тестирование методов в сервисах

        public void Task_1_CreateDefaultUser() // создаем 1 человека в базе
        {
            usersService.CreateUser(new UserDto
            {
                FirstName = "Evgeniy",
                LasttName = "Genadievich",
                IsBlocked = false
            });
            ordersService.CreateOrder(new OrderDto
            {
                Date = DateTime.Now,
                OrderSum = 999,
                UserId = 1
            });

            Console.Write(usersService.GetUserById(1));
            Console.WriteLine(" was created");
        }


        public void Task_2_FindUsersByName()
        {
            string name = "Evgeniy";
            var srchUsers = usersService.GetUsersByName(name);
            int count = 0;

            Console.WriteLine($"List of people with name '{name}':");
            srchUsers.ForEach(user =>
            {
                Console.WriteLine($"[{++count}] {user}");
            });

            if (count == 0)
            {
                Console.WriteLine("Users not found");
            }
        }


        public void Task_3_BlockSelectedUser()
        {
            var user = GetSelectedEntity(usersService.GetAllUsers());
            
            if (user != null)
            {
                usersService.BlockUser(user.Id);

                Console.Write(usersService.GetUserById(user.Id));
                Console.WriteLine(" was blocked");
            }
        }


        public void Task_4_MakeOrderForUser()
        {
            var customer = GetSelectedEntity(usersService.GetAllUsers());
            if (customer != null)
            {
                Console.WriteLine("Enter sum: ");
                decimal sum;
                decimal.TryParse(Console.ReadLine(), out sum);

                ordersService.MakeOrder(sum, customer.Id);
                Console.WriteLine("Order added.");
                ShowEntitiesList<OrderDto>(ordersService.GetOrdersByUserId(customer.Id));
            }
        }


        public void Task_5_ShowOrdersSelectedUser()
        {
            var srchUser = GetSelectedEntity(usersService.GetAllUsers());
            ShowEntitiesList<OrderDto>(ordersService.GetOrdersByUserId(srchUser.Id));
        }


        public void Task_6_ShowOrdersByRange()
        {
            DateTime from = new DateTime(2021, 02, 10);
            DateTime to = DateTime.Now;
            Console.WriteLine($"All orders from {from.ToShortDateString()} to {to.ToShortDateString()}");
            var ordersRange = ordersService.GetRangeByDate(from, to);
            ShowEntitiesList<OrderDto>(ordersRange);
        }
    }
}
