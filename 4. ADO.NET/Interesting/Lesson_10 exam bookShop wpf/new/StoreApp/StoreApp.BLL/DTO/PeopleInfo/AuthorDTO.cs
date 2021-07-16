using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO.PeopleInfo
{
    public class AuthorDTO : PersonDTO
    {
        public List<BookDTO> Books { get; set; }

        public override string ToString() => $"{FullName}";
    }
}
