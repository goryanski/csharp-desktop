using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.PeopleInfo;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.PeopleInfo
{
    public class CustomersService : ICustomersService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public CustomersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateCustomer(CustomerDTO customer)
        {
            var result = objectMapper.Mapper.Map<Customer>(customer);
            uow.CustomersRepository.Create(result);
            uow.Save();
        }

        public CustomerDTO GetCustomerById(int id)
        {
            var result = uow.CustomersRepository.Get(id);
            return objectMapper.Mapper.Map<CustomerDTO>(result);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            var result = uow.CustomersRepository.GetAll();
            return objectMapper.Mapper.Map<List<CustomerDTO>>(result);
        }
    }
}
