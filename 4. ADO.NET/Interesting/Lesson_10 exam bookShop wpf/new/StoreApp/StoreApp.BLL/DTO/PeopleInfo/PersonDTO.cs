using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO.PeopleInfo
{
    public abstract class PersonDTO : BaseDTO
    {
        public string FullName { get; set; }
    }
}
