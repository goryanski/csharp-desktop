using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Application
    {
        Plane plane = new Plane();
       
        public void Start()
        {
            while (true)
            {
                Menu();
                int action;
                int.TryParse(Console.ReadLine(), out action);
                RunMenuAction(action);
            }
        }

        private void RunMenuAction(int action)
        {
            switch (action)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

        private void StartGame()
        {
            Console.Clear();

            // обнулим значения
            ResetValues();

            // по условию задания пилот должен набирать себе диспечеров сам перед полетом
            AddDispatchers();

            // подпишем на события еще 2 метода, которые будут выводить на экран текущую скорость и высоту, что бы можно было как-то понимать как проходит полет
            plane.ChangeHeightEvent += ShowCurrentHeight;
            plane.ChangeSpeedEvent += ShowCurrentSpeed;

            ShowInstruction();

            // будем объявлять заново с каждой новой игрой что бы сбрасывать false, при срабатывании исключений
            bool playing = true; 

            while (playing)
            {
                var key = Console.ReadKey();
                bool isDownShift = key.Modifiers == ConsoleModifiers.Shift;
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            plane.Move(Plane.Action.IncreaseHeight, isDownShift);
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            plane.Move(Plane.Action.DecreaseHeight, isDownShift);
                            break;
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            plane.Move(Plane.Action.DecreaseSpeed, isDownShift);
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            plane.Move(Plane.Action.IncreaseSpeed, isDownShift);
                            break;

                            // для добавления/удвления диспечеров во время игры
                        case ConsoleKey.D1:
                            AddOneDispatcher();
                            break;
                        case ConsoleKey.D2:
                            RemoveOneDispatcher();
                            break;
                    }

                    Console.WriteLine();

                    plane.ChangeFlightState();

                    if (plane.MissionCompleted)
                    {
                        ShowStatistics();
                        playing = false;
                    }    
                }
                catch (CrashPlaneException ex)
                {
                    Console.WriteLine(ex.Message);
                    playing = false;
                }
                catch (InvalidPilotException ex)
                {
                    Console.WriteLine(ex.Message);
                    playing = false;
                }
                finally
                {
                    // в самом конце игры, в любом случае отписываем от событий изменения скорости и высоты все методы и всех диспечеров, иначе, при запуске новой игры подписки останутся и информация на экран будет выводиться по нескольку раз со старыми данными и новыми, даже если очистим массив диспечеров полностью
                    if(playing == false)
                    {
                        plane.UnsubscribeAllDispatchers();
                        plane.ChangeHeightEvent -= ShowCurrentHeight;
                        plane.ChangeSpeedEvent -= ShowCurrentSpeed;
                    }
                }
            }
        }

        private void ResetValues()
        {
            // инициализируем все поля класса дефолтными значениями и будем это делать каждый раз при запуке новой игры, поскольку информация в классе остается с предыдущих игр
            plane.InitializePlane();
            // и при каждой новой игре будем сбрасывать общее кол-во штрафных очков
            Dispatcher.GeneralPenalty = 0;           
        }

        private void Menu()
        {
            Console.WriteLine("\nNew game:");
            Console.WriteLine("[1] Начать полет");
            Console.WriteLine("[2] Выйти");
        }

        private void AddDispatchers()
        {
            Console.WriteLine("First, add dispatchers.");
            Console.Write($"How many dispatchers you want to add?" +
                $"(from {Plane.MIN_DISPATCHERS} to {Plane.MAX_DISPATCHERS}) ");

            int count;
            int.TryParse(Console.ReadLine(), out count);

            while(count < Plane.MIN_DISPATCHERS || count > Plane.MAX_DISPATCHERS)
            {
                Console.Write("Wrong number, try again ");
                int.TryParse(Console.ReadLine(), out count);
            }           

            string name = string.Empty;
            for (int i = 0; i < count; i++)
            {
                AddOneDispatcher(name);
            }            
        }

        private void AddOneDispatcher(string name)
        {
            Console.Write("\nEnter name: ");
            name = Console.ReadLine();
            plane.AddDispatcher(new Dispatcher(name));
            Console.WriteLine($"{name} was added.");
        }

        private void AddOneDispatcher()
        {
            if (plane.CountDispatchers < Plane.MAX_DISPATCHERS)
            {
                Console.WriteLine("Adding a dispatcher:");
                string name = string.Empty;
                AddOneDispatcher(name);
            }
            else
            {
                Console.WriteLine("You can't to add more dispatchers");
            }
            Console.WriteLine("You can continue to fly");           
        }

        private void RemoveOneDispatcher()
        {
            if (plane.CountDispatchers > Plane.MIN_DISPATCHERS)
            {
                Console.WriteLine("Removing a dispatcher");
                Console.WriteLine("Dispatchers list:");
                int count = 0;
                for (int i = 0; i < plane.CountDispatchers; i++)
                {
                    Console.WriteLine($"[{++count}] {plane.Dispatchers[i]}");
                }

                int select;
                int.TryParse(Console.ReadLine(), out select);

                int size = plane.Dispatchers.Length;
                while (select < 1 || select > size)
                {
                    Console.Write("Wrong number, try again ");
                    int.TryParse(Console.ReadLine(), out select);
                }

                plane.UnsubscribeDispatcher(plane.Dispatchers[select - 1]);
                plane.RemoveDispatcher(plane.Dispatchers[select - 1]);
                Console.WriteLine("Dispatcher was removed.");
            }
            else
            {
                Console.WriteLine($"You can't to remove dispatcher, if amount of your dispatchers is less than {Plane.MIN_DISPATCHERS}");
            }
            Console.WriteLine("You can continue to fly");          
        }

        public static void ShowCurrentSpeed(Plane plane)
        {
            Console.WriteLine($"Current speed: {plane.Speed}");
        }
        private void ShowCurrentHeight(Plane plane)
        {
            Console.WriteLine($"Current height: {plane.Height}");
        }

        private void ShowInstruction()
        {
            Console.WriteLine($"\nYour task: При рекомендуемой высоте полета (которую будут объявлять диспечера) \nнабрать скорость {Plane.MAX_SPEED} км/ч, а затем посадить самолет \n(снижать скорость и высоту, пока самолет не сядет) \nШтрафные очки начисляются за отклонения от рекомендуемой высоты и от превышения максимальной скорости. \nСумма штрафов не должна превысить {Dispatcher.MAX_PENALTY} и разница между \nрекомендуемой высотой и реальной не должна привысить {Dispatcher.MAX_DIFFERENT}");

            Console.WriteLine("В процессе полета пилот может добавлять и удалять своих диспечеров. \nДля добавления нажмите 1, для удаления - 2. \nНо меньше 2-x диспечеров во время полета быть не может");
            Console.WriteLine("GO!!!");
        }

        private void ShowStatistics()
        {
            Console.WriteLine("You won!");

            // соберем очки у удаленных диспечеров 
            int generalPenalty = Dispatcher.GeneralPenalty;

            // и прибавим очки каждого активного диспечера
            for (int i = 0; i < plane.Dispatchers.Length; i++)
            {
                generalPenalty += plane.Dispatchers[i].Penalty;
            }

            Console.WriteLine($"Общее кол-во штрафных очков от всех диспечеров (включая удаленных) - {generalPenalty}"); ;
        }
    }
}
