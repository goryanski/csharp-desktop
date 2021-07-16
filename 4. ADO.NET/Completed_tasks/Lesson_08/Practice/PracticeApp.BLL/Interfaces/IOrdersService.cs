using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.BLL.DTO;

namespace PracticeApp.BLL.Interfaces
{
    public interface IOrdersService
    {
        void CreateOrder(OrderDto order);
        OrderDto GetOrderById(int id);
    }
}
