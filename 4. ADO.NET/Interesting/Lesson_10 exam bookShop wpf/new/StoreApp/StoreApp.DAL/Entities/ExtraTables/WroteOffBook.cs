using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities.ExtraTables
{
    public class WroteOffBook : BaseEntity<int>
    {
        public int BookId { get; set; }
        public DateTime Date { get; set; }
    }
}
