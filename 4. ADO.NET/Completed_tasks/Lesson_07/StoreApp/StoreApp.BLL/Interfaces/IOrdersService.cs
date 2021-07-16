using StoreApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.Interfaces
{
    public interface IOrdersService
    {
        void CreateOrder(OrderDto order);
        OrderDto GetOrderById(int id);
        //List<OrderDto> GetOrdersInPriceRange(decimal from, decimal to);
    }
}
