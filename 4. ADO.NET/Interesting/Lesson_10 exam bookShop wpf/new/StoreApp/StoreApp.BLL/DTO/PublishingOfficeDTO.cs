using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO
{
    public class PublishingOfficeDTO : BaseDTO
    {
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
