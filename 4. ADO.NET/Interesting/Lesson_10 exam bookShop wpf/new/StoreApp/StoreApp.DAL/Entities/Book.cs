using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.DAL.Entities
{
    public class Book : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public decimal PrimeCost { get; set; }
        public decimal Price { get; set; }
        public bool IsSequel { get; set; }
        public int Discount { get; set; }
        public bool IsExist { get; set; }
        public int PublishYear { get; set; }
        public int AmountInStorage { get; set; }

        public List<Author> Authors { get; set; }
        public PublishingOffice PublishingOffice { get; set; }
        public int PublishingOfficeId { get; set; }
    }
}
