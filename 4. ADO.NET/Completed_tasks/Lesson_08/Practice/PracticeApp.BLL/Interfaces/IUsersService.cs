using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeApp.BLL.DTO;

namespace PracticeApp.BLL.Interfaces
{
    public interface IUsersService
    {
        void CreateUser(UserDto user);
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
    }
}
