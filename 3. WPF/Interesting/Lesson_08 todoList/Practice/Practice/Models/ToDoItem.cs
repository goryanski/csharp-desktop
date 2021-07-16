using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Practice.Commands;
using Practice.Models.Helpers;
using Practice.ViewModels;

namespace Practice.Models
{
    [Serializable]
    public class ToDoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _name = string.Empty;
        string _description = string.Empty;
        DateTime _dateStart = DateTime.Now;
        DateTime _dateEnd = DateTime.Now;
        string _state = string.Empty;
        int _priority = 0;
        SolidColorBrush _bckgColor = Utils.inProgressBckgColor;
        private PackIconKind _stateIcon = Utils.waitIcon;


        public PackIconKind StateIcon
        {
            get => _stateIcon;
            set
            {
                if (_stateIcon != value)
                {
                    _stateIcon = value;
                    OnPropertyChanged(nameof(StateIcon));
                }
            }
        }
        public SolidColorBrush BackgroundColor
        {
            get => _bckgColor;
            set
            {
                if (_bckgColor != value)
                {
                    _bckgColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (!value.Equals(_name))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (!value.Equals(_description))
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public DateTime DateStart
        {
            get => _dateStart;
            set
            {
                if (_dateStart != value)
                {
                    _dateStart = value;
                    OnPropertyChanged(nameof(DateStart));
                }
            }
        }
        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                if (_dateEnd != value)
                {
                    _dateEnd = value;
                    OnPropertyChanged(nameof(DateEnd));
                }
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if (!value.Equals(_state))
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }
        public int Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
