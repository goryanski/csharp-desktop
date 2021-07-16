using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderSum { get; set; } 
        public UserDto User { get; set; }
        public int UserId { get; set; }

        public override string ToString() => $"Sum: {OrderSum}, Date: {Date.ToShortDateString()}";
    }
}
