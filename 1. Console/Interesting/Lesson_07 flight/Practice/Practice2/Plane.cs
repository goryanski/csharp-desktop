using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Plane
    {
        public enum Action
        {
            IncreaseSpeed,
            DecreaseSpeed,
            IncreaseHeight,
            DecreaseHeight
        }
        const int SPEED_STEP = 50;
        const int SPEED_FAST_STEP = 150;
        const int HEIGHT_STEP = 250;
        const int HEIGHT_FAST_STEP = 500;
        public const int MAX_SPEED = 1000;

        //событие изменения высоты
        public event Action<Plane> ChangeHeightEvent;
        public event Action<Plane> ChangeSpeedEvent;

        public int Speed { get; private set; }
        public int Height { get; private set; }


        //общее кол-во диспетчеров
        public int CountDispatchers { get; set; }
        // максимальное и минимальное кол-во диспетчеров
        public const int MIN_DISPATCHERS = 2;
        public const int MAX_DISPATCHERS = 10;

        public Dispatcher[] Dispatchers { get; set; }

        // статусы полета
        public bool PlaneStarted { get; set; }
        public bool PlaneFinishing { get; set; }

        bool taskCompleted;
        public bool MissionCompleted { get; set; }

        // инициализация всех полей изначальными значениями для корректного повторения игры 
        public void InitializePlane()
        {
            Speed = 0;
            Height = 0;
            CountDispatchers = 0;
            PlaneStarted = false;
            PlaneFinishing = false;
            taskCompleted = false;
            MissionCompleted = false;
            Dispatchers = new Dispatcher[MAX_DISPATCHERS];        
        }

        public void ChangeFlightState()
        {
            if (Speed > 0 && Speed <= SPEED_STEP)
            {
                PlaneStarted = true;
            }
            if(Speed == MAX_SPEED)
            {
                taskCompleted = true;
            }
            if(Speed <= SPEED_STEP && Height <= HEIGHT_STEP && taskCompleted)
            {
                PlaneFinishing = true;
                MissionCompleted = true;
            }
        }

        public void Move(Action action, bool fasted = false)
        {
            switch (action)
            {
                case Action.IncreaseSpeed:
                    IncreaseSpeed(fasted);
                    break;
                case Action.DecreaseSpeed:
                    DecreaseSpeed(fasted);
                    break;
                case Action.IncreaseHeight:
                    IncreaseHeight(fasted);
                    break;
                case Action.DecreaseHeight:
                    DecreaseHeight(fasted);
                    break;
                default:
                    break;
            }
        }
        private void IncreaseSpeed(bool fasted = false)
        {
            Speed += (fasted ? SPEED_FAST_STEP : SPEED_STEP);
            ChangeSpeedEvent?.Invoke(this);
        }
        private void DecreaseSpeed(bool fasted = false)
        {
            Speed -= (fasted ? SPEED_FAST_STEP : SPEED_STEP);
            ChangeSpeedEvent?.Invoke(this);
        }
        private void IncreaseHeight(bool fasted = false)
        {
            if (Speed > 100)
            {
                Height += (fasted ? HEIGHT_FAST_STEP : HEIGHT_STEP);
                ChangeHeightEvent?.Invoke(this);
            }
            else
            {
                Console.WriteLine("You can't to fly up, while your speed not more than 100");
            }
        }
        private void DecreaseHeight(bool fasted = false)
        {
            Height -= (fasted ? HEIGHT_FAST_STEP : HEIGHT_STEP);
            ChangeHeightEvent?.Invoke(this);
        }

        public void AddDispatcher(Dispatcher dispatcher)
        {
            if (CountDispatchers < MAX_DISPATCHERS)
            {
                // изначально память в массива  была выделена на 10 эл-тов для того что бы пилот при взлете мог добавить 10 диспечеров, если нужно, но после удаления из массива диспечера в прецессе игры, массив обрезался до фактического размера и  теперь памяти под него выделено столько же, сколько в нем элементов (это нужно для того что бы при отображении массива на экране не было пуслых ячеек и не было возможности пилоту  некорректно выбрать элемент массива)  и если мы удаляли диспечера из массива в процессе игра, то теперь при добавлении в процессе игры нужно выделять память под каждый новый элемент.
                if (Dispatchers.Length < MAX_DISPATCHERS)
                {
                    Dispatchers = new Dispatcher[Dispatchers.Length + 1];
                }
                Dispatchers[CountDispatchers++] = dispatcher;
                //подписка диспетчера на события корректировок
                ChangeHeightEvent += dispatcher.CorrectHeight;
                ChangeSpeedEvent += dispatcher.CorrectSpeed;
            }
        }

        public void RemoveDispatcher(Dispatcher dispatcher)
        {
            // перед тем как удалять диспечера запишем его кол-во штрафных очков для статистики
            Dispatcher.GeneralPenalty += dispatcher.Penalty;

            Dispatcher[] tmp = new Dispatcher[CountDispatchers - 1];
            int j = 0;
            for (int i = 0; i < CountDispatchers; i++)
            {
                // здесь перегрузили !=
                if (Dispatchers[i] != dispatcher)
                {
                    tmp[j++] = Dispatchers[i];
                }
            }
            Dispatchers = tmp;
            CountDispatchers--;
        }

        public void UnsubscribeDispatcher(Dispatcher dispatcher)
        {
            //отписка диспетчера от событий корректировок
            ChangeHeightEvent -= dispatcher.CorrectHeight;
            ChangeSpeedEvent -= dispatcher.CorrectSpeed;
        }
        public void UnsubscribeAllDispatchers()
        {
            for (int i = 0; i < CountDispatchers; i++)
            {
                UnsubscribeDispatcher(Dispatchers[i]);
            } 
        }
    }
}
