using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DAL.Entities.PeopleInfo
{
    public class Author : Person
    {
        public List<Book> Books { get; set; }
    }
}