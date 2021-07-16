using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    [Serializable]
    public class Result : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _userName = string.Empty;
        private int _score = 0;

        public string UserName
        {
            get => _userName;
            set
            {
                if (!_userName.Equals(value))
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                if (!_score.Equals(value))
                {
                    _score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
