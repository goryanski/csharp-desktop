using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.UI.WPF.Helpers
{
    // этот класс нужен только для удобной валидации книги
    public class BookModelValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pages { get; set; }
        public string Genre { get; set; }
        public decimal PrimeCost { get; set; }
        public decimal Price { get; set; }
        public string Discount { get; set; }
        public string PublishYear { get; set; }
        public string AmountInStorage { get; set; }
        public string PublishingOffice { get; set; }
        public bool IsSequel { get; set; }

        public string Author1 { get; set; }
        public string Author2 { get; set; }
        public string Author3 { get; set; }
        public string Author4 { get; set; }
        public string Author5 { get; set; }
    }
}
