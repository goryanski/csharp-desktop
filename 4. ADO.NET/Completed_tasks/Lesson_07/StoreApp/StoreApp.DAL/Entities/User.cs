using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public bool IsBlocked { get; set; }
        public List<Order> Orders { get; set; }
    }
}
