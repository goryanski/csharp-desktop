using StoreApp.BLL.DTO;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private IUnitOfWork uow;
        private StoreApp.BLL.Automapper.ObjectMapper objectMapper = StoreApp.BLL.Automapper.ObjectMapper.Instance;

        public OrdersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateOrder(OrderDto order)
        {
            var result = objectMapper.Mapper.Map<Order>(order);
            uow.OrdersRepository.Create(result);
            uow.Save();
        }

        public OrderDto GetOrderById(int id)
        {
            var order = uow.OrdersRepository.Get(id);
            return objectMapper.Mapper.Map<OrderDto>(order);
        }

        public void MakeOrder(decimal sum, int id)
        {
            var ord = new OrderDto { Date = DateTime.Now, OrderSum = sum, UserId = id };
            CreateOrder(ord);
        }

        public List<OrderDto> GetRangeByDate(DateTime from, DateTime to)
        {
            var orders = uow.OrdersRepository.GetAll().Where(o => o.Date >= from && o.Date <= to).ToList();
            return objectMapper.Mapper.Map<List<OrderDto>>(orders);
        }
    }
}
