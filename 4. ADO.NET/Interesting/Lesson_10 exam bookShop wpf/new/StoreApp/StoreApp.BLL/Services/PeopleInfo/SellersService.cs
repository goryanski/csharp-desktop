using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.PeopleInfo;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.PeopleInfo
{
    public class SellersService : ISellersService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public SellersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateSeller(SellerDTO seller)
        {
            var result = objectMapper.Mapper.Map<Seller>(seller);
            uow.SellersRepository.Create(result);
            uow.Save();
        }

        public SellerDTO GetSellerById(int id)
        {
            var seller = uow.SellersRepository.Get(id);
            return objectMapper.Mapper.Map<SellerDTO>(seller);
        }

        public SellerDTO GetSellerByLogin(string login)
        {
            // по скольку мы не можем добавлять продавцов в таблицу с одинаковыми логинами (по валидации) то они точно будут уникальные
            var seller = uow.SellersRepository.GetAll()
                .FirstOrDefault(s => s.Login == login);
            
            return objectMapper.Mapper.Map<SellerDTO>(seller);
        }

    }
}
