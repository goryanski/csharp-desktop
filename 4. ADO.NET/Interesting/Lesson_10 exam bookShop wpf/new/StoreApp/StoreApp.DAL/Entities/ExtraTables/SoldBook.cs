using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.DAL.Entities.ExtraTables
{
    public class SoldBook : BaseEntity<int>
    {
        public int BookId { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
