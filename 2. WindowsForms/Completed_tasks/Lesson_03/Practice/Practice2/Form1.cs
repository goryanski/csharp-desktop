using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
  2. Разработать приложение, созданное на основе
        формы.
            ■ Пользователь «щелкает» левой кнопкой мыши по
                форме и, не отпуская кнопку, ведет по ней мышку,
                а в момент отпускания кнопки по полученным координатам прямоугольника (вам, конечно, известно,
                что двух точек на плоскости достаточно для создания прямоугольника) необходимо создать «статик»,
                который содержит свой порядковый номер (имеется
                в виду порядок появления на форме).
            ■ Минимальный размер «статика» составляет 10×10,
                при попытке создания элемента меньших размеров
                пользователь должен увидеть соответствующее предупреждение.
            ■ При щелчке правой кнопкой мыши над поверхностью
                «статика» в заголовке окна должна появиться информация о его площади и координатах (относительно
                формы). В случае, если в точке щелчка находится несколько «статиков», то предпочтение отдается «статику» с наибольшим порядковым номером.
            ■ При двойном щелчке левой кнопки мыши над поверхностью «статика» он должен исчезнуть с формы.
                В случае, если в точке щелчка находится несколько «статиков», то предпочтение отдается «статику»
                с наименьшим порядковым номером.
 */

namespace Practice2
{
    public partial class Form : System.Windows.Forms.Form
    {
        public int FormWidth { get; set; }
        public int FormHeight { get; set; }

        public int Xstart { get; set; }
        public int Ystart { get; set; }
        public int Xend { get; set; }
        public int Yend { get; set; }
     
        int btnLocationX;
        int btnLocationY;
        int btnWidth;
        int btnHeight;

        int counter = 0;
        Random rnd = new Random();
        Dictionary<int, Color> colors;

        bool isPressedOnce = false;
        bool isButttonDeletingNow = false;
        string checkButtonText;
        Timer timer; 

        public Form()
        {
            InitializeComponent();

            FormWidth = this.ClientRectangle.Width;
            FormHeight = this.ClientRectangle.Height;

            colors = new Dictionary<int, Color>
            {
                {1,  Color.CadetBlue},
                {2,  Color.Maroon},
                {3,  Color.Gold},
                {4,  Color.LightGreen},
                {5,  Color.Plum}
            };

            timer = new Timer { Interval = 400 };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            isButttonDeletingNow = false;
            isPressedOnce = false;
            timer.Stop();
            
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Xstart = e.X;
                Ystart = e.Y;

                // при создании новой кнопки
                Text = "";
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            // если прямо сейчас происходит удаление кнопки - игнорируем это событие, т.к. оно возникает неявным образом во время удаления 
            if(!isButttonDeletingNow)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Xend = e.X;
                    Yend = e.Y;
                    if (Xend < 0 || Yend < 0 || Xend > FormWidth || Yend > FormHeight)
                    {
                        MessageBox.Show("Rectangle out of range");
                    }
                    else
                    {
                        // если прямогугольник 10х10 и больше
                        if (Math.Abs(Xend - Xstart) >= 10 && Math.Abs(Yend - Ystart) >= 10)
                        {
                            // потянули влево вниз
                            if (Xend < Xstart && Yend > Ystart)
                            {
                                FillBtnProperties(Xend, Ystart, Xstart - Xend, Yend - Ystart);
                            }
                            // потянули влево вверх
                            else if (Xend < Xstart && Yend < Ystart)
                            {
                                FillBtnProperties(Xend, Yend, Xstart - Xend, Ystart - Yend);
                            }
                            // потянули вправо вверх
                            else if (Xend > Xstart && Yend < Ystart)
                            {
                                FillBtnProperties(Xstart, Yend, Xend - Xstart, Ystart - Yend);
                            }
                            // потянули вправо вниз
                            else if (Xend > Xstart && Yend > Ystart)
                            {
                                FillBtnProperties(Xstart, Ystart, Xend - Xstart, Yend - Ystart);
                            }

                            CreateNewButton();
                        }
                        else
                        {
                            MessageBox.Show("Rectangle is too small");
                        }
                    }
                }
            }           
        }

        void CreateNewButton()
        {
            Button btn = new Button
            {
                Text = $"{++counter}",
                Location = new Point(btnLocationX, btnLocationY),
                Size = new Size(btnWidth, btnHeight),
                TextAlign = ContentAlignment.TopLeft
            };

            int setColor = rnd.Next(1, colors.Count + 1);

            btn.BackColor = colors[setColor];
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = colors[setColor];

            Controls.Add(btn);

            btn.MouseDown += (s, args) =>
            {
                Button button = s as Button;
                if (args.Button == MouseButtons.Right)
                {
                    ShowInfoButton();                  
                }
                else if (args.Button == MouseButtons.Left)
                {
                    DoubleClickСustom(button);
                }
            };       
        }

        private void ShowInfoButton()
        {
            foreach (Button control in Controls)
            {
                Point location = control.PointToScreen(Point.Empty);
                if (MousePosition.X > location.X && MousePosition.X < location.X + control.Width && MousePosition.Y > location.Y && MousePosition.Y < location.Y + control.Height)
                {
                    Text = $"Static №{control.Text}, Area {control.Width * control.Height}, Location Х = {control.Location.X} Y = {control.Location.Y}";
                }
            }
        }

        void FillBtnProperties(int locationX, int locationY, int width, int height)
        {
            btnLocationX = locationX;
            btnLocationY = locationY;
            btnWidth = width;
            btnHeight = height;
        }

        void DoubleClickСustom(Button button)
        {
            // создадим свой DoubleClick, для этого воспользуемся таймером
            if (!isPressedOnce)
            {
                isPressedOnce = true;
                timer.Start();
                // так же будем сохранять кнопку, по которой нажали, и потом проверять, по ней ли мы нажали второй раз. что бы нельзя было быстро нажать по двум разным кнопкам и это засчиталось бы на двойной клик
                checkButtonText = button.Text;
            }
            else
            {
                if (checkButtonText.Equals(button.Text))
                {
                    Controls.Remove(button);
                    isButttonDeletingNow = true;
                    Text = "";
                }
            }
        }
    }
}
