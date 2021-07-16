using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Practice.Models.Helpers
{
    class TargetsStorage
    {
        private static TargetsStorage instance;
        public static TargetsStorage Instance { get => instance ?? (instance = new TargetsStorage()); }
        public ToDoItem EnteredTarget { get; set; }
        public ObservableCollection<ToDoItem> Targets { get; set; }
        private TargetsStorage() => InitDefaultTargets();

        private void InitDefaultTargets()
        {
            Targets = new ObservableCollection<ToDoItem>
            {
                new ToDoItem
                {
                    Name = $"Купить продукты",
                    Description = $"Хлеб, соль, молоко, селедка",
                    Priority = 4,
                    State = Utils.inProgressState,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddDays(1)
                },
                new ToDoItem
                {
                    Name = $"Стоматолог",
                    Description = $"Поставить пломбу",
                    Priority = 5,
                    State = Utils.inProgressState,
                    DateStart = DateTime.Now,
                    DateEnd = DateTime.Now.AddDays(7)
                },
                new ToDoItem
                {
                    Name = $"Ремонт",
                    Description = $"Отнести телевизор на ремонт",
                    Priority = 3,
                    State = Utils.doneState,
                    DateStart =  new DateTime(2020, 05, 20),
                    DateEnd = new DateTime(2020, 12, 31),
                    BackgroundColor = Utils.doneBckgColor
                },
                new ToDoItem
                {
                    Name = $"Расстаться с девушкой",
                    Description = $"В пятый раз уже точно",
                    Priority = 5,
                    State = Utils.overdueState,
                    DateStart =  new DateTime(2017, 01, 20),
                    DateEnd = new DateTime(2017, 03, 07),
                    BackgroundColor = Utils.overdueBckgColor
                }
            };
        }       


        internal void MoveItemToBottom(ToDoItem item)
        {
            int idx = Targets.IndexOf(item);
            Targets.Move(idx, Targets.Count - 1);
        }

        internal void MoveItemToTop(ToDoItem item)
        {
            int idx = Targets.IndexOf(item);
            Targets.Move(idx, 0);
        }

    }
}
