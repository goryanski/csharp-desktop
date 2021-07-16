using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using StoreApp.BLL.DTO.PeopleInfo;
using StoreApp.DAL.Entities.PeopleInfo;

namespace StoreApp.BLL.DTO
{
    public class BookDTO : BaseDTO, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // будем отслеживать изменения только тех полей, которые будут показаны в листбоксе, остальные нет смысла
        private string _name = string.Empty;
        private string _genre = string.Empty;
        private decimal _price = 0;
        private int _count = 0;

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
        public int Pages { get; set; }
        public string Genre
        {
            get => _genre;
            set
            {
                if (!_genre.Equals(value))
                {
                    _genre = value;
                    OnPropertyChanged(nameof(Genre));
                }
            }
        }
        public decimal PrimeCost { get; set; }
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
        public bool IsSequel { get; set; }
        public int Discount { get; set; }
        public bool IsExist { get; set; }
        public int PublishYear { get; set; }
        public int AmountInStorage
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(AmountInStorage));
                }
            }
        }

        public List<AuthorDTO> Authors { get; set; }
        public PublishingOfficeDTO PublishingOffice { get; set; }
        public int PublishingOfficeId { get; set; }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
