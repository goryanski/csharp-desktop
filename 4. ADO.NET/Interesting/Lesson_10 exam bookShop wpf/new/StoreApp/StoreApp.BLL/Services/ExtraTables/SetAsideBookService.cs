using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.ExtraTables
{
    public class SetAsideBookService : ISetAsideBookService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public SetAsideBookService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateSetAsideBook(SetAsideBookDTO book)
        {
            var result = objectMapper.Mapper.Map<SetAsideBook>(book);
            uow.SetAsideBooksRepository.Create(result);
            uow.Save();
        }

        public SetAsideBookDTO GetSetAsideBookById(int id)
        {
            var result = uow.SetAsideBooksRepository.Get(id);
            return objectMapper.Mapper.Map<SetAsideBookDTO>(result);
        }
    }
}
