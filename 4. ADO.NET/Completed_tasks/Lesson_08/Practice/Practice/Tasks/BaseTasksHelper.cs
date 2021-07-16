using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.BLL.DTO;
using PracticeApp.BLL.Services;
using PracticeApp.DAL.Interfaces;
using PracticeApp.DAL.Repositories;

namespace Practice.Tasks
{
    public abstract class BaseTasksHelper
    {
        UnitOfWork uow;
        protected UsersService usersService;
        protected OrdersService ordersService;

        public BaseTasksHelper()
        {
            uow = new UnitOfWork(@"Data Source=DESKTOP-RG3HTFI;Initial Catalog=smallShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            usersService = new UsersService(uow);
            ordersService = new OrdersService(uow);
        }


        public List<T> ShowEntitiesList<T>(List<T> entity)
        {
            if (entity.Count > 0)
            {
                Console.WriteLine("\nFull list:");
                int count = 0;
                entity.ForEach((e) =>
                {
                    Console.WriteLine($"[{++count}] {e}");
                });
            }
            else
            {
                Console.WriteLine("There are nothing");
            }

            return entity;
        }

        public T GetSelectedEntity<T>(List<T> entity) where T : UserDto
        {
            List<T> entities = ShowEntitiesList(entity);
            if (entities.Count > 0)
            {
                Console.Write("\nChoose number: ");
                int select;
                int.TryParse(Console.ReadLine(), out select);

                while (select < 1 || select > entities.Count)
                {
                    Console.Write("Wrong number, try again: ");
                    int.TryParse(Console.ReadLine(), out select);
                }
                return entities[select - 1];
            }
            return null;
        }
    }
}
