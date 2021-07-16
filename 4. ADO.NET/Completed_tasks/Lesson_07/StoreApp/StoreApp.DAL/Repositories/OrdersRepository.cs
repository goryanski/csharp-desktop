using StoreApp.DAL.EF;
using StoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Repositories
{
    public class OrdersRepository : BaseRepository<Order, int>
    {
        public OrdersRepository(StoreContext context) : base(context)
        {
        }

        public override void Update(Order entity)
        {
        }
    }
}
