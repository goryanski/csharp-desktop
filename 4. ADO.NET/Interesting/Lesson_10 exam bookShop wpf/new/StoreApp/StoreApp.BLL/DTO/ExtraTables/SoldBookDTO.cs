using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;

namespace StoreApp.BLL.DTO.ExtraTables
{
    public class SoldBookDTO : BaseDTO
    {
        public int BookId { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
