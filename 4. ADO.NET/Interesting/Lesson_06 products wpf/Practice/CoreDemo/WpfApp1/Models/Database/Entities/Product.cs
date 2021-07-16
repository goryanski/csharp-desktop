using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfApp1.Models.Database.Entities;

namespace WpfApp1.Models.Database.Models
{
    public class Product : BaseEntity, ICloneable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name = string.Empty;
        private decimal _price = 0;
        private int _categoryId = 0;
        private Category _category = null;

        public string Name
        {
            get => _name;
            set
            {
                if (!_name.Equals(value))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public int CategoryId
        {
            get => _categoryId;
            set
            {
                if (_price != value)
                {
                    _categoryId = value;
                    OnPropertyChanged(nameof(CategoryId));
                }
            }
        }
        public Category Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            Product product = new Product();
            product.Copy(this);
            return product;
        }

        public void Copy(Product from)
        {
            Name = from.Name;
            Price = from.Price;
            CategoryId = from.CategoryId;
            Category = from.Category;
        }
    }
}
