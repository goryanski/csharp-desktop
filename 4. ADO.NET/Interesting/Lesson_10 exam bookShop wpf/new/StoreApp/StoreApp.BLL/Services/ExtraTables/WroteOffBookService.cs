using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.ExtraTables
{
    public class WroteOffBookService : IWroteOffBookService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public WroteOffBookService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateWroteOffBook(WroteOffBookDTO book)
        {
            var result = objectMapper.Mapper.Map<WroteOffBook>(book);
            uow.WroteOffBooksRepository.Create(result);
            uow.Save();
        }


        public WroteOffBookDTO GetWroteOffBookById(int id)
        {
            var result = uow.WroteOffBooksRepository.Get(id);
            return objectMapper.Mapper.Map<WroteOffBookDTO>(result);
        }
    }
}
