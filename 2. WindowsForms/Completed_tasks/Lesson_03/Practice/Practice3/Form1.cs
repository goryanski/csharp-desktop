using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice3
{
    /*
        3. Разработать приложение «убегающий статик».
            Суть приложения: на форме расположен статический 
            элемент управления («статик»). Пользователь пытается
            подвести курсор мыши к «статику», и, если курсор находиться близко со статиком, элемент управления «убегает».
            Предусмотреть перемещение «статика» только в пределах
            формы. 
   
     */

    public partial class Form : System.Windows.Forms.Form
    {
        Button runner;
        public Form()
        {
            InitializeComponent();
            runner = new Button();
        }

     
        private void Form_Load(object sender, EventArgs e)
        {        
            runner.Size = new Size(50, 50);
            runner.FlatStyle = FlatStyle.Flat;
            SetNormalColor();
            Controls.Add(runner);

            SetInCenter(runner);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            // если курсор приближается
            if ((e.X > runner.Location.X - 10 && e.X < runner.Location.X + runner.Width + 10) && (e.Y > runner.Location.Y - 10 && e.Y < runner.Location.Y + runner.Height + 10))
            {
                // вправо
                if (e.X > runner.Location.X - 10 && e.X < runner.Location.X)
                {
                    runner.Left += 5;
                }
                // влево
                else if (e.X < runner.Location.X + runner.Width + 10 && e.X > runner.Location.X + runner.Width)
                {
                    runner.Left -= 5;
                }
                // вниз
                else if (e.Y > runner.Location.Y - 10 && e.Y < runner.Location.Y)
                {
                    runner.Top += 5;
                }
                // вверх
                else if (e.Y < runner.Location.Y + runner.Height + 10 && e.Y > runner.Location.Y + runner.Height)
                {
                    runner.Top -= 5;
                }

                // если подходим к границе
                if ((runner.Location.X < 30 || runner.Location.X > ClientSize.Width - runner.Width - 30) || (runner.Location.Y < 30 || runner.Location.Y > ClientSize.Height - runner.Width - 30))
                {
                    SetDangerColor();
                }
                else
                {
                    SetNormalColor();
                }

                // если подошли к границе
                if ((runner.Location.X < 0 || runner.Location.X > ClientSize.Width - runner.Width) || (runner.Location.Y < 0 || runner.Location.Y > ClientSize.Height - runner.Height))
                {
                    SetNormalColor();
                    SetInCenter(runner);
                }
            }
        }

        void SetInCenter(Button runner) 
        {          
            runner.Left = (ClientSize.Width - runner.Size.Width) / 2;
            runner.Top = (ClientSize.Height - runner.Size.Height) / 2;
        }


        void SetNormalColor()
        {
            runner.BackColor = Color.CadetBlue;
            runner.FlatAppearance.BorderColor = Color.CadetBlue;
        }
        void SetDangerColor()
        {
            runner.BackColor = Color.Red;
            runner.FlatAppearance.BorderColor = Color.Red;
        }
    }
}
