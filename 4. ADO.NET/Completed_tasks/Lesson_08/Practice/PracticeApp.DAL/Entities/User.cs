using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.DAL.Entities
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public bool IsBlocked { get; set; }
        public List<Order> Orders { get; set; }
    }
}
