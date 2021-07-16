using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.Models;
using Practice.Models.Helpers;
using Practice.ViewModels;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TargetsStorage targetsStorage = TargetsStorage.Instance;
        TargetValidator validator = new TargetValidator();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDoItem item = lbTargets.SelectedItem as ToDoItem;
            if(item != null)
            {
                if(item.State.Equals(Utils.inProgressState))
                { 
                    item.StateIcon = Utils.completeIcon;
                }
                else
                {
                    item.StateIcon = Utils.refreshIcon;
                }
            }
            EditDatePicker.SelectedDate = DateTime.Today.AddDays(1);
        }

        private void BtnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem item = lbTargets.SelectedItem as ToDoItem;
            if (item != null)
            {
                if (item.State.Equals(Utils.inProgressState))
                {
                    item.BackgroundColor = Utils.doneBckgColor;
                    item.State = Utils.doneState;
                    // и еще раз обновляем иконку уже после нажития кнопки, по сколько событие SelectionChanged срабатывает только при изменении выбора, а если бы хотим сразу же вернуть ствтул обратно у этого же элемента, то иконка не обновится
                    item.StateIcon = Utils.refreshIcon;
                    targetsStorage.MoveItemToBottom(item);
                }
                else
                {
                    item.State = Utils.inProgressState;
                    item.BackgroundColor = Utils.inProgressBckgColor;
                    item.StateIcon = Utils.completeIcon;
                    item.DateEnd = DateTime.Today.AddDays(1);
                    targetsStorage.MoveItemToTop(item);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem target = new ToDoItem();
            target.Name = tbAddName.Text;
            target.Description = tbAddDescription.Text;
            string date = AddDatePicker.SelectedDate.ToString();
            string priority = tbAddPriority.Text;
            SaveEnteredTarget(target, priority, date);

            tbAddName.Text = string.Empty;
            tbAddDescription.Text = string.Empty;
            tbAddPriority.Text = string.Empty;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem target = new ToDoItem();
            target.Name = tbEditName.Text;
            target.Description = tbEditDescription.Text;
            string date = EditDatePicker.SelectedDate.ToString();
            string priority = tbEditPriority.Text;
            // нет смысла редактировать, если задание не возобновится в списке для его выполнения, по этопу нам вполне подейдет выполнить те же действия, что и для добавления
            SaveEnteredTarget(target, priority, date);
        }

        private void SaveEnteredTarget(ToDoItem target, string priority, string date)
        {
            if (validator.IsTargetValid(target, priority, date))
            {
                target.DateEnd = Convert.ToDateTime(date);
                target.Priority = int.Parse(priority);
                target.State = Utils.inProgressState;
                target.BackgroundColor = Utils.inProgressBckgColor;
                target.StateIcon = Utils.completeIcon;

                targetsStorage.EnteredTarget = target;
            }
        }
    }
}
