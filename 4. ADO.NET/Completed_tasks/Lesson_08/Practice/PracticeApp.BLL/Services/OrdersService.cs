using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.BLL.DTO;
using PracticeApp.BLL.Interfaces;
using PracticeApp.DAL.Entities;
using PracticeApp.DAL.Interfaces;

namespace PracticeApp.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public OrdersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateOrder(OrderDto order)
        {
            var result = objectMapper.Mapper.Map<Order>(order);
            uow.OrdersRepository.Create(result);
            
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

        public List<OrderDto> GetOrdersByUserId(int id)
        {
            var orders = uow.OrdersRepository.GetAll().Where(o => o.UserId == id).ToList();
            return objectMapper.Mapper.Map<List<OrderDto>>(orders);
        }
    }
}
