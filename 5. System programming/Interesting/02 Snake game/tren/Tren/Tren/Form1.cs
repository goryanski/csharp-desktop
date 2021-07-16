using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tren.App;

namespace Tren
{
    /*
      классы Snake и Food создавать нет смысла - воспользуемся готовыми PictureBox и Label, все что не разбито по файлам работает напрямую с формой и дальнейшее разбитие только усложнит читабельность 
     */
    public partial class Game : Form
    {
        // движение элемента по х и у
        int moveByX, moveByY;
        bool gameOver;
        int score;

        List<PictureBox> snake = new List<PictureBox>();
        PictureBox snakeHead;

        Task taskMove, taskFoodGenerate, taskUpdateGame;
        CancellationTokenSource sourceAllTasks;
        CancellationToken token;

        CreateHelper creator = new CreateHelper();

        public Game()
        {
            InitializeComponent();
            
            new Settings();
            FormInit();
            this.Load += Game_Load;
            this.KeyDown += Game_KeyDown;
        }

        private void FormInit()
        {
            this.Width = Settings.FieldWidth;
            this.Height = Settings.FieldHeight;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        void StartNewGame()
        {
            InitGlobalVariables();
            CreateMap();
            CreateSnakeHead();
            ShowScore();

            // при запуске новой игры сбразываем в null, иначе змея не будет ползти  
            sourceAllTasks = null;
            sourceAllTasks = new CancellationTokenSource();
            
            token = sourceAllTasks.Token;
            taskMove = Task.Run(MoveSnake, token);
            taskFoodGenerate = Task.Run(GenerateFood, token);
            taskUpdateGame = Task.Run(CheckEvents, token);
        }



        private void InitGlobalVariables()
        {
            score = 0;
            gameOver = false;

            // игра начнется с движения только по х(вправо)
            moveByX = 1;
            moveByY = 0;

            snake.Clear();
            this.Controls.Clear();
        }
        private void CreateMap()
        {
            // заполняем "палочками" из PictureBox все доступное пространство, что бы получилась сетка - для точного подсчета координат и корректного передвижения змеи, а так же что бы координаты еды четко совпадали с координатам головы змеи и не возникало ошибок при попытке съесть еду из-за несовпадения координат
            for (int i = 0; i < Settings.FieldWidth / Settings.SellSize; i++)
            {
                this.Controls.Add
                (
                    creator.CreateGrigItem(i, "byX")
                );
            }
            for (int i = 0; i <= Settings.FieldHeight / Settings.SellSize; i++)
            {
                this.Controls.Add
                (
                    creator.CreateGrigItem(i, "byY")
                );
            }
        }
        private void CreateSnakeHead()
        {
            snakeHead = creator.CreateSnakePart(0, 0);
            snakeHead.BackColor = Color.MediumVioletRed;
            snake.Add(snakeHead);
            this.Controls.Add(snakeHead);
        }
        private void ShowScore()
        {
            this.Text = $"Your score: {score * 10}";
        }


        #region Tasks
        private void MoveSnake()
        {
            while (!gameOver)
            {
                BeginInvoke(new Action(() =>
                {
                    // здесь мы будем проверять нажатие клавиш через определенный промежуток времени (Settings.Speed) и меняем координаты головы змеи, в зависимости от того, какая клавиша нажата, если не нажата никакая, просто движемся в направлении последней нажатой клавиши
                    // используем переменную score так же и для цикла что бы каждая часть змеи меняла свои координаты следуя за хвостом 
                    for (int i = score; i >= 1; i--)
                    {
                        snake[i].Location = snake[i - 1].Location;
                    }
                    snakeHead.Location = new Point(snakeHead.Location.X + moveByX * Settings.SellSize, snakeHead.Location.Y + moveByY * Settings.SellSize);
                }));
                Thread.Sleep(Settings.Speed);
            }
        }
        private void GenerateFood()
        {
            while (!gameOver)
            {
                BeginInvoke(new Action(() =>
                {
                    var point = creator.CreateNewLocation();
                    Label food = creator.CreateFood(point.X, point.Y);

                    this.Controls.Add(food);
                }));
                Thread.Sleep(Settings.Speed * 10);
            }
        }
        private void CheckEvents()
        {
            while (!gameOver)
            {
                BeginInvoke(new Action(() =>
                {
                    // event #1 - столкновение с едой
                    foreach (var control in this.Controls)
                    {
                        if (control is Label)
                        {
                            var food = control as Label;
                            if (food.Location.X == snakeHead.Location.X &&
                            food.Location.Y == snakeHead.Location.Y)
                            {
                                this.Controls.Remove(food);
                                AddTail();
                                ShowScore();
                            }
                        }
                    }


                    // event #2 - столкновение с границами поля
                    // что бы узнать точное расположение границы получим размер рабочей области и вычнем размер одной ячейки что бы вовремя среагировать на выход за границу
                    int realWidth = this.ClientRectangle.Width - Settings.SellSize;
                    int realHeight = this.ClientRectangle.Height - Settings.SellSize;

                    if (snakeHead.Location.X < 0 || snakeHead.Location.Y < 0 ||
                    snakeHead.Location.X > realWidth || snakeHead.Location.Y > realHeight)
                    {
                        Die("Collision with border");
                    }



                    // event #3 - столкновение с собой
                    // начинаем с i = 1 что бы голову не учитывать
                    for (int i = 1; i < snake.Count; i++)
                    {
                        if(snakeHead.Location.X == snake[i].Location.X &&
                        snakeHead.Location.Y == snake[i].Location.Y)
                        {
                            Die("Collision with body");
                        } 
                        // таким образом, пока у змеи не больше 2-х частей, мы можем изменить направление движения змеи на противоболожное, а с увеличением частей это уже будет считаться столкновением с собой
                    }
                }));
                Thread.Sleep(Settings.Speed / 2);
            }           
        }
        #endregion


        private void AddTail()
        {
            // добавим на координаты головы, просто что бы не видно было куда он добавился, а в процессе MoveSnake он уже сам стaнет на нужное место - в хвост
            PictureBox tail = creator.CreateSnakePart(-100, -100); // установим несуществующие координаты, что бы новая часть не появлялась посреди поля
            snake.Add(tail);
            this.Controls.Add(tail);
            score++;
        }
        private void Die(string why)
        {
            gameOver = true;
            sourceAllTasks.Cancel();
            MessageBox.Show("You died. Press enter to repeat", why);
            StartNewGame();
        }

      
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    moveByX = 1; // идем вправо 
                    moveByY = 0; // не идем никуда 
                    break;
                case Keys.Left:
                    moveByX = -1; // идем влево
                    moveByY = 0;
                    break;
                case Keys.Up:
                    moveByY = -1;
                    moveByX = 0;
                    break;
                case Keys.Down:
                    moveByY = 1;
                    moveByX = 0;
                    break;
            }
        }
    }
}
