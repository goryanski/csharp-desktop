using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.BLL.DTO.ExtraTables
{
    public class SetAsideBookDTO : BaseDTO
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
