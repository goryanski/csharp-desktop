using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.DAL.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public decimal OrderSum { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
