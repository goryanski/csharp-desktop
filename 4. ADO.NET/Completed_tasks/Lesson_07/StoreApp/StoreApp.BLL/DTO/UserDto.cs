using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public bool IsBlocked { get; set; }
        public List<OrderDto> Orders { get; set; }

        public override string ToString() => $"{FirstName} {LasttName}";
    }
}
