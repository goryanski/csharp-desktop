using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Calc calc;

        const string SCREEN_DEFAULT_TEXT = "0";       
        public bool IsOperationPressed { get; set; }
        public bool IsSimpleVersion { get; set; }

        public Calculator()
        {
            InitializeComponent();

            calc = new Calc();
            IsOperationPressed = false;
            IsSimpleVersion = true;
            #region some information for me
            // вместо MouseEnter/MouseLeave для подсветки кнопок воспользовался 
            //this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            //this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;

            // для того что бы нельзя было менять размер калькулятора ползунками во время использования 
            // FromBorderStyle - FixedDialog
            #endregion
        }

        private void ButtonNum_Click(object sender, EventArgs e)
        {
            // сразу очистим экран от нуля и так же будем очищать, если был введен арифмет.знак
            if (screen.Text.Equals(SCREEN_DEFAULT_TEXT) || IsOperationPressed)
            {
                screen.Text = "";
            }


            // после нажатия очередной кнопки(цифры) можем снова вводить арифмет.знаки
            IsOperationPressed = false;
            Button btn = sender as Button;


            // если запятую нажать в самом начале будет 0,
            if (btn.Text == "," && screen.Text == "")
            {
                screen.Text = $"{SCREEN_DEFAULT_TEXT}{btn.Text}";
            }
            // что бы запятую нельзя было нажать больше чем один раз
            else if ((btn.Text == "," && !screen.Text.Contains(",")) || btn.Text != ",")
            {
                screen.Text += btn.Text;
            }  
        }
        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // IsSimpleVersion - простая версия это когда мы после каждого действия нажимаем =, например 10+10 = 10+10 = и т.д. а не простая версия, это когда мы нажимаем 10+10+10+10 и калькулятор считает без нажатия =
            // специально не выносил дублирующий код из if else что бы четко видно було где простая версия а где нет, а то легко запутаться и ошибиться
            if (IsSimpleVersion)
            {
                calc.Operation = btn.Text;
                calc.Result = double.Parse(screen.Text);
                IsOperationPressed = true;
                // лейбл слева вверху где будем показывать промежуточный результат для удобства
                labelMemory.Text = $"{calc.Result} {calc.Operation}";
                IsSimpleVersion = false;
            }
            else
            {
                // нужно запретить нажимать здесь 2 знака подряд
                if (!IsOperationPressed)
                {
                    // разница между версиями в том что мы очередной арифмет.оператор неявно используем как =, при этом он все равно выполняет свою функцию
                    screen.Text = calc.Calculate(screen.Text);

                    calc.Operation = btn.Text;
                    calc.Result = double.Parse(screen.Text);
                    IsOperationPressed = true;
                    labelMemory.Text = $"{calc.Result} {calc.Operation}";
                }
            }
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            labelMemory.Text = "";
            screen.Text = calc.Calculate(screen.Text);
            IsSimpleVersion = true;
        }


        // кнопка <-- очистка последнего символа
        private void ButtonClearLast_Click(object sender, EventArgs e)
        {
            if (screen.Text.Length == 1 && screen.Text != SCREEN_DEFAULT_TEXT)
            {
                screen.Text = SCREEN_DEFAULT_TEXT;
            }
            else if (screen.Text != SCREEN_DEFAULT_TEXT)
            {
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
            }

        }

        // кнопка СЕ - очистим только поле ввода, а в памяти информация останется 
        private void ButtonClearScreen_Click(object sender, EventArgs e)
        {
            screen.Text = SCREEN_DEFAULT_TEXT;
        }

        // кнопка С - очистим и поле ввода и память
        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            // обнуляем все настройки
            screen.Text = SCREEN_DEFAULT_TEXT;
            calc.Result = 0;
            labelMemory.Text = "";
            IsSimpleVersion = true;
            IsOperationPressed = false;
        }
    }
}
