using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services
{
    public class BooksService : IBooksService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public BooksService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateBook(BookDTO book)
        {
            var result = objectMapper.Mapper.Map<Book>(book);
            uow.BooksRepository.Create(result);
            uow.Save();
        }

        public BookDTO GetBookById(int id)
        {
            var result = uow.BooksRepository.Get(id);
            return objectMapper.Mapper.Map<BookDTO>(result);
        }

        public List<BookDTO> GetAllBooks()
        {
            var result = uow.BooksRepository.GetAll();
            return objectMapper.Mapper.Map<List<BookDTO>>(result);
        }

        public List<BookDTO> GetAllBooksWithAuthors()
        {
            var result = uow.BooksRepository.GetAllBooksWithAuthors();
            return objectMapper.Mapper.Map<List<BookDTO>>(result);
        }

        public void DecreaseCountBooksInStock(int id)
        {
            uow.BooksRepository.DecreaseCountBooksInStock(id);
            uow.Save();
        }

        public void RemoveBook(int id)
        {
            uow.BooksRepository.Delete(id);
            uow.Save();
        }


        public void UpdateBook(BookDTO bookDTO)
        {
            var res = objectMapper.Mapper.Map<Book>(bookDTO);
            uow.BooksRepository.Update(res);
            uow.Save();
        }

        public BookDTO GetFullBookInfo(int id)
        {
            var fullBook = uow.BooksRepository.GetFullBookInfo(id);
            return objectMapper.Mapper.Map<BookDTO>(fullBook);
        }

        public void SetDiscount(int id, int discount)
        {
            uow.BooksRepository.SetDiscount(id, discount);
            uow.Save();
        }
    }
}
