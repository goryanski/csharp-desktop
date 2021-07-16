using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Controls;

namespace Practice.Helpers
{
    [Serializable]
    public class SavedProduct
    {      
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }     
        public string Seller { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Picture { get; set; }
        public int Rating { get; set; }

        public void Copy(Product from)
        {
            Title = from.Title;
            Price = from.Price;
            Description = from.Description;
            Seller = from.Seller;
            Category = from.Category;
            CreatedDate = from.CreatedDate;
            Picture = from.Picture;
            Rating = from.Rating;
        }
    }
}
