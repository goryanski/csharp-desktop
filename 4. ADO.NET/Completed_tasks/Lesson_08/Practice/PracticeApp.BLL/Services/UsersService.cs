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
    public class UsersService : IUsersService
    {
        private IUnitOfWork uow;
        private Automapper.ObjectMapper objectMapper = Automapper.ObjectMapper.Instance;
        public UsersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateUser(UserDto user)
        {
            var result = objectMapper.Mapper.Map<User>(user);
            uow.UsersRepository.Create(result);
        }

        public List<UserDto> GetAllUsers()
        {
            var user = uow.UsersRepository.GetAll();
            return objectMapper.Mapper.Map<List<UserDto>>(user);
        }

        public UserDto GetUserById(int id)
        {
            var user = uow.UsersRepository.Get(id);
            return objectMapper.Mapper.Map<UserDto>(user);
        }

        public List<UserDto> GetUsersByName(string firstname)
        {
            var user = uow.UsersRepository.GetAll().Where(u => u.FirstName == firstname);
            return objectMapper.Mapper.Map<List<UserDto>>(user);
        }

        public void BlockUser(int id)
        {
            uow.UsersRepository.BlockUser(id);
        }
    }
}
