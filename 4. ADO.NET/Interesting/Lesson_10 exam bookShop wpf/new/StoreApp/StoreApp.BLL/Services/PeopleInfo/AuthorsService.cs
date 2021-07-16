using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities.PeopleInfo;
using StoreApp.DAL.Interfaces;

namespace StoreApp.BLL.Services.PeopleInfo
{
    public class AuthorsService : IAuthorsService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;

        public AuthorsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateAuthor(AuthorDTO author)
        {
            var result = objectMapper.Mapper.Map<Author>(author);
            uow.AuthorsRepository.Create(result);
            uow.Save();
        }

        public AuthorDTO GetAuthorById(int id)
        {
            var result = uow.AuthorsRepository.Get(id);
            return objectMapper.Mapper.Map<AuthorDTO>(result);
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            var result = uow.AuthorsRepository.GetAll();
            return objectMapper.Mapper.Map<List<AuthorDTO>>(result);
        }
    }
}
