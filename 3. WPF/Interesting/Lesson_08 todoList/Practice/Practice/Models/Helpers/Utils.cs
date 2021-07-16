using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace Practice.Models.Helpers
{
    public class Utils
    {
        public const string inProgressState = "in progress";
        public const string doneState = "done";
        public const string overdueState = "overdue";

        public const PackIconKind waitIcon = PackIconKind.ProgressClock;
        public const PackIconKind refreshIcon = PackIconKind.Restore;
        public const PackIconKind completeIcon = PackIconKind.CheckOutline;

        // их нельзя объявить константными, но нужно получать доступ в разных местах, и что бы в одном месте можно было их поменять - объявим статическими
        public static SolidColorBrush inProgressBckgColor = new SolidColorBrush(Color.FromRgb(255, 244, 158));
        public static SolidColorBrush doneBckgColor = new SolidColorBrush(Color.FromRgb(176, 176, 176));
        public static SolidColorBrush overdueBckgColor = new SolidColorBrush(Color.FromRgb(255, 17, 0));
    }
}
