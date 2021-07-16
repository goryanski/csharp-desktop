using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WpfApp1.Models.Database.Entities;

namespace WpfApp1.Models.Database.Models
{
    public class Category : BaseEntity, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name = string.Empty;
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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Product> Products { get; set; }
    }
}
