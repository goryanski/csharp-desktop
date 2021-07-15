using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Dispatcher
    {
        public const int MAX_PENALTY = 1000;
        public const int MAX_DIFFERENT = 1000;
        private static Random rnd = new Random();

        // здесь будет храниться общее кол-во штрафных очков (и даже от удаленных диспечеров) 
        public static int GeneralPenalty { get; set; } = 0;
        //корректировка погодных условий
        private readonly int weather;
        //имя диспечера 
        public string Name { get; set; }
        //штрафные очки
        public int Penalty { get; set; }

        public Dispatcher(string name)
        {
            Name = name;
            weather = rnd.Next(-200, 201);
        }

        public void CorrectHeight(Plane plane)
        {
            // по условию: управление самолетом диспетчерами начинается (прекращается) при наборе (при снижении) самолетом скорости более (менее) 50 км/ч
            if (plane.Speed >= 50)
            {
                var recomendedHeight = 7 * plane.Speed - weather;
                Console.Write($"[{Name}] - Рекомендованная высота = {recomendedHeight}");

                var diff = Math.Abs(recomendedHeight - plane.Height);

                //пилот набрал максимальное кол-во штрафных очей
                if (Penalty >= MAX_PENALTY)
                {
                    throw new InvalidPilotException();
                }

                //проверки высоты полета самолета
                if (diff >= 300 && diff < 600)
                {
                    Penalty += 25;
                }
                else if (diff >= 600 && diff < 1000)
                {
                    Penalty += 50;
                }
                else if (diff > MAX_DIFFERENT)
                {
                    throw new CrashPlaneException($"\n\nPазница между рекомендуемой высотой и реальной превысила {MAX_DIFFERENT}");
                }

                Console.WriteLine($" | Your penalties: {Penalty}");                     
            }
            // по заданию: Так же недопустимо, чтобы самолет в любой момент времени имел нулевую высоту (Кроме момента начала взлета и посадки). По этому в классе Рlane мы ввели сосояния полета самотела такие как  planeStarted и planeFinishing
            if (plane.Height <= 0 && plane.PlaneStarted && !plane.PlaneFinishing)
            {
                throw new CrashPlaneException("\n\nPlane cannot have Height <= 0, while it's in the sky");
            }
        }

        public void CorrectSpeed(Plane plane)
        {
            //самолет превысил скорость
            if (plane.Speed > Plane.MAX_SPEED)
            {
                Console.WriteLine($"[{Name}], Немедленно снизьте скорость!");
                Penalty += 100;
            }

            // по заданию: Так же недопустимо, чтобы самолет в любой момент времени имел нулевую скорость(Кроме момента начала взлета и посадки )
            if (plane.Speed <= 0 && plane.PlaneStarted && !plane.PlaneFinishing)
            {
                throw new CrashPlaneException("\n\nPlane cannot have Speed <= 0, while it's in the sky");
            }
            if (plane.Speed > 200 && plane.Height == 0)
            {
                throw new CrashPlaneException("\n\nСамолет набрал слишком большую скорость и не взлетел");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Penalty count: {Penalty}";
        }

        public static bool operator == (Dispatcher dispatcher1, Dispatcher dispatcher2)
        {
            return dispatcher1.Name.Equals(dispatcher2.Name);
        }
        public static bool operator != (Dispatcher dispatcher1, Dispatcher dispatcher2)
        {
            return !(dispatcher1 == dispatcher2);
        }
    }
}
