using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.DTO.ExtraTables;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.ExtraTables;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.ExtraTables
{
    public class SoldBooksService : ISoldBooksService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public SoldBooksService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateBook(SoldBookDTO book)
        {
            var result = objectMapper.Mapper.Map<SoldBook>(book);
            uow.SoldBooksRepository.Create(result);
            uow.Save();
        }

        public SoldBookDTO GetBookById(int id)
        {
            var result = uow.SoldBooksRepository.Get(id);
            return objectMapper.Mapper.Map<SoldBookDTO>(result);
        }

        public List<SoldBookDTO> GetAllBooks()
        {
            var result = uow.SoldBooksRepository.GetAll();
            return objectMapper.Mapper.Map<List<SoldBookDTO>>(result);
        }

        public List<BookDTO> GeTMostPopularBooks()
        {
            var result = uow.SoldBooksRepository.GeTMostPopularBooks();
            return objectMapper.Mapper.Map<List<BookDTO>>(result);
        }

        public List<AuthorDTO> GetAuthorsMostPopularBooks()
        {
            var result = uow.SoldBooksRepository.GetAuthorsMostPopularBooks();
            return objectMapper.Mapper.Map<List<AuthorDTO>>(result);
        }
    }
}
