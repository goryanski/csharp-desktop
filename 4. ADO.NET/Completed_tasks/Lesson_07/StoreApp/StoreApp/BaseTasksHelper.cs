
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.Services;
using StoreApp.DAL.Interfaces;
using StoreApp.DAL.Repositories;

namespace StoreApp.UI.Console
{
    public abstract class BaseTasksHelper
    {
        IUnitOfWork uow;
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
                System.Console.WriteLine("\nFull list:");
                int count = 0;
                entity.ForEach((e) =>
                {
                    System.Console.WriteLine($"[{++count}] {e}");
                });
            }
            else
            {
                System.Console.WriteLine("There are nothing");
            }

            return entity;
        }

        public T GetSelectedEntity<T>(List<T> entity) where T : UserDto
        {
            List<T> entities = ShowEntitiesList(entity);
            if (entities.Count > 0)
            {
                System.Console.Write("\nChoose number: ");
                int select;
                int.TryParse(System.Console.ReadLine(), out select);

                while (select < 1 || select > entities.Count)
                {
                    System.Console.Write("Wrong number, try again: ");
                    int.TryParse(System.Console.ReadLine(), out select);
                }
                return entities[select - 1];
            }
            return null;
        }
    }
}
