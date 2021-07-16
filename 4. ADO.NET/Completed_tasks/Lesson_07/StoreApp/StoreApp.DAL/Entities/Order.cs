using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public decimal OrderSum { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
