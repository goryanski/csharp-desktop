using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*1.Представьте, что у вас на форме есть прямоугольник, границы которого на 10 пикселей отстоят от границ
     рабочей области формы. Необходимо создать следующие
     обработчики:
        ■ Обработчик нажатия левой кнопки мыши, который
            выводит сообщение о том, где находится текущая
            точка: внутри прямоугольника, снаружи, на границе
            прямоугольника. Если при нажатии левой кнопки
            мыши была нажата кнопка Control (Ctrl), то приложение должно закрываться.
        ■ Обработчик нажатия правой кнопки мыши, который
            выводит в заголовок окна информацию о размере клиентской (рабочей) области окна в виде: Ширина = x,
            Высота = y, где x и y — соответствующие параметры
            выcшего окна. 
        ■ Обработчик перемещения указателя мыши в пределах рабочей области, который должен выводить
            в заголовок окна текущие координаты мыши x и y.
*/

namespace Practice
{
    public partial class Form : System.Windows.Forms.Form
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int FormWidth { get; set; }
        public int FormHeight { get; set; }

        bool formClosing;

        public Form()
        {
            InitializeComponent();

            FormWidth = this.ClientRectangle.Width;
            FormHeight = this.ClientRectangle.Height;

            formClosing = false;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            Text = $"X:{X} Y{Y}";
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey)
            {
                formClosing = true;
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                formClosing = false;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Ширина = {FormWidth}  Высота = {FormHeight}";
            }
            else if(e.Button == MouseButtons.Left)
            {
                if (formClosing == true)
                {
                    this.Close();
                }
                else if (X == 10 || Y == 10 || X == (FormWidth - 10) || Y == (FormHeight - 10))
                {
                    MessageBox.Show("Point is on the border");
                }
                else if (X < 10 || Y < 10 || X > (FormWidth - 10) || Y > (FormHeight - 10))
                {
                    MessageBox.Show("Point out of range");
                }
                else
                {
                    MessageBox.Show("Point is into a rectangle");
                }
            }
        }
    }
}
