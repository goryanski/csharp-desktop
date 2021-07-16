using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.BLL.Interfaces
{
    public interface ICustomersService
    {
        void CreateCustomer(CustomerDTO customer);
        CustomerDTO GetCustomerById(int id);
    }
}
