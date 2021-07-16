using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.BLL.Interfaces
{
    public interface IAuthorsService
    {
        void CreateAuthor(AuthorDTO author);
        AuthorDTO GetAuthorById(int id);
    }
}
