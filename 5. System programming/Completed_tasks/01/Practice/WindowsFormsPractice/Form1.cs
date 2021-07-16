using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsPractice.Models;

namespace WindowsFormsPractice
{
    public partial class Form1 : Form
    {
        enum Car
        {
            Zhigul,
            Lanos,
            Porsche,
            Bmw
        }

        Thread threadZhigul, threadLanos, threadPorsche, threadBmw;
        bool isRace= true;
        Random rnd = new Random();
        int pbLocationFinish;
        bool isRestart = false;

        public Form1()
        {
            InitializeComponent();

            pBoxInit();
        }

        private void pBoxInit()
        {
            string image = Path.GetFullPath("finish_start.jpg");
            pictureBox.Image = Image.FromFile(image);

            pbLocationFinish = pictureBox.Location.X + pictureBox.Width - 65;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartGame();

            if (isRestart)
            {
                isRace = true;
                threadZhigul = threadLanos = threadPorsche = threadBmw = null;
            }

            threadZhigul = new Thread(new ParameterizedThreadStart(Race));
            threadZhigul.Start(Car.Zhigul);

            threadLanos = new Thread(new ParameterizedThreadStart(Race));
            threadLanos.Start(Car.Lanos);

            threadPorsche = new Thread(new ParameterizedThreadStart(Race));
            threadPorsche.Start(Car.Porsche);

            threadBmw = new Thread(new ParameterizedThreadStart(Race));
            threadBmw.Start(Car.Bmw);

            threadZhigul.IsBackground = threadLanos.IsBackground = threadPorsche.IsBackground = threadBmw.IsBackground = true;
        }

        private void StartGame()
        {
            BeginInvoke(new Action(() =>
            {
                btnZhigul.Location = new Point(78, 41);
                btnLanos.Location = new Point(78, 78);
                btnPorsche.Location = new Point(78, 110);
                btnBmw.Location = new Point(78, 142);

                lblResult.Text = string.Empty;
                btnStart.Enabled = false;
            }));
        }

        private void Race(object param)
        {
            Car car = (Car)param;
            while (isRace)
            {
                int movement = rnd.Next(25, 40);
                BeginInvoke(new Action(() =>
                {
                    switch (car)
                    {
                        case Car.Zhigul:
                            if (btnZhigul.Location.X >= pbLocationFinish)
                            {
                                isRace = false;
                            }
                            else
                            {
                                btnZhigul.Location = new Point(
                                    btnZhigul.Location.X + movement, btnZhigul.Location.Y
                                );
                            }
                            break;
                        case Car.Lanos:
                            if (btnLanos.Location.X >= pbLocationFinish)
                            {
                                isRace = false;
                            }
                            else
                            {
                                btnLanos.Location = new Point(
                                        btnLanos.Location.X + movement, btnLanos.Location.Y
                                    );
                            }
                            break;
                        case Car.Porsche:
                            if (btnPorsche.Location.X >= pbLocationFinish)
                            {
                                isRace = false;
                            }
                            else
                            {
                                btnPorsche.Location = new Point(
                                        btnPorsche.Location.X + movement, btnPorsche.Location.Y
                                    );
                            }
                            break;
                        case Car.Bmw:
                            if (btnBmw.Location.X >= pbLocationFinish)
                            {
                                isRace = false;
                            }
                            else
                            {
                                btnBmw.Location = new Point(
                                        btnBmw.Location.X + movement, btnBmw.Location.Y
                                    );
                            }
                            break;
                    }
                }));
                Thread.Sleep(rnd.Next(500, 1200));
            }
            ShowResults();
        }

        private void ShowResults()
        {
            BeginInvoke(new Action(() =>
            {
                List<BtnCar> cars = new List<BtnCar>
                {
                    new BtnCar { Name =  btnZhigul.Text, Position = btnZhigul.Location.X},
                    new BtnCar { Name =  btnLanos.Text, Position = btnLanos.Location.X},
                    new BtnCar { Name =  btnPorsche.Text, Position = btnPorsche.Location.X},
                    new BtnCar { Name =  btnBmw.Text, Position = btnBmw.Location.X}
                };
                

                var results = cars.OrderByDescending(c => c.Position);
                lblResult.Text = "Results:\n";

                int counter = 0;
                foreach (var car in results)
                {
                    lblResult.Text += $"{++counter} - {car.Name}\n";
                }
                btnStart.Enabled = true;
                isRestart = true;
            }));           
        }


    }
}