using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities
{
    public class PublishingOffice : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
