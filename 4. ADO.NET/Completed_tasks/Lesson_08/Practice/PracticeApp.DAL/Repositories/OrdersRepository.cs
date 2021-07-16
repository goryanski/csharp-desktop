using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PracticeApp.DAL.Entities;
using PracticeApp.DAL.Interfaces;

namespace PracticeApp.DAL.Repositories
{
    public class OrdersRepository : IRepository<Order, int>
    {
        IDbConnection db;
        public OrdersRepository(IDbConnection context)
        {
            db = context;
        }

        public void Create(Order entity)
        {
            db.Query("INSERT INTO Orders VALUES (@date, @orderSum, @userId)",
                new
                {
                    date = entity.Date,
                    orderSum = entity.OrderSum,
                    userId = entity.UserId
                });
        }

        public void Delete(int id)
        {
            db.Query("DELETE Orders WHERE id = @id", new { id = id });
        }

        public Order Get(int id)
        {
            return db.QueryFirstOrDefault<Order>("SELECT * FROM Orders WHERE id = @id",
                    new
                    {
                        id = id
                    });
        }

        public List<Order> GetAll()
        {
            return db.Query<Order>("SELECT * FROM Orders").ToList();
        }
    }
}
