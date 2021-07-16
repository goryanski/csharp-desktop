using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    [Serializable]
    public class Contact : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _photo = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _address = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!_firstName.Equals(value))
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (!_lastName.Equals(value))
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public string Photo
        {
            get => _photo;
            set
            {
                if (!_photo.Equals(value))
                {
                    _photo = value;
                    OnPropertyChanged(nameof(Photo));
                }
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (!_phoneNumber.Equals(value))
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (!_address.Equals(value))
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public override string ToString()
            => $"{LastName} {FirstName}";

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            Contact contact = new Contact();
            contact.Copy(this);
            return contact;
        }

        public void Copy(Contact from)
        {
            FirstName = from.FirstName;
            LastName = from.LastName;
            Photo = from.Photo;
            PhoneNumber = from.PhoneNumber;
            Address = from.Address;
        }
    }
}
