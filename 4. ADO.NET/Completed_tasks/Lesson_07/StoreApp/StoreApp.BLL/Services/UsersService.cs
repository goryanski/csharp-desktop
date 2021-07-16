using StoreApp.BLL.DTO;
using StoreApp.BLL.Interfaces;
using StoreApp.DAL.Entities;
using StoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace StoreApp.BLL.Services
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork uow;
        private StoreApp.BLL.Automapper.ObjectMapper objectMapper = StoreApp.BLL.Automapper.ObjectMapper.Instance;
        public UsersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateUser(UserDto user)
        {
            var result = objectMapper.Mapper.Map<User>(user);
            uow.UsersRepository.Create(result);
            uow.Save();
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
            var user = uow.UsersRepository.Get(id);
            user.IsBlocked = true;
            uow.Save();
        }
    }
}
