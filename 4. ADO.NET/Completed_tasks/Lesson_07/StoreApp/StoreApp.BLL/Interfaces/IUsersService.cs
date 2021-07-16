using StoreApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(UserDto user);
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
    }
}
