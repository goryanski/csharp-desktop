using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Practice.Commands;
using Practice.Models;
using Practice.Models.Helpers;

namespace Practice.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        TargetsStorage targetsStorage = TargetsStorage.Instance;
        public ObservableCollection<ToDoItem> Items { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        // инициализируем так что бы иконка загружалась нужная при старте
        private ToDoItem _selectedItem = new ToDoItem { StateIcon = Utils.waitIcon, Name = "not selected" };
        public ToDoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }                             
            }
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        private ProcessCommand _addCommand;
        public ProcessCommand AddCommand => _addCommand ?? (_addCommand = new ProcessCommand(obj => {
            ToDoItem item = targetsStorage.EnteredTarget;
            if (item != null)
            {
                targetsStorage.Targets.Insert(0, item);
            }              
        }));


        private ProcessCommand _editCommand;
        public ProcessCommand EditCommand => _editCommand ?? (_editCommand = new ProcessCommand(obj =>
        {
            ToDoItem selectedItem = obj as ToDoItem;
            ToDoItem editedItem = targetsStorage.EnteredTarget;
            if(editedItem != null)
            {
                targetsStorage.Targets.Remove(selectedItem);
                targetsStorage.Targets.Insert(0, editedItem);
            }
            
        }, obj => obj != null && (obj as ToDoItem).Name != "not selected"));


        private ProcessCommand _removeCommand;
        public ProcessCommand RemoveCommand => _removeCommand ?? (_removeCommand = new ProcessCommand(obj =>
        {
            ToDoItem selectedItem = obj as ToDoItem;
            targetsStorage.Targets.Remove(selectedItem);

        }, obj =>  obj != null && (obj as ToDoItem).Name != "not selected"));
      

        public MainViewModel()
        {
            Items = targetsStorage.Targets;
        }
    }
}
