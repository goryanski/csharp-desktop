using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities.ExtraTables
{
    public class SetAsideBook : BaseEntity<int>
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
