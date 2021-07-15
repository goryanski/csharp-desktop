using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    class Program
    {
        static readonly string[] requests = new string[]
        {
            "Feed me!",
            "Walk with me!",
            "I want to sleep!",
            "I want to play!",
            "Cure me"
        };
        
        static Action<string> DecreeseHealthEvent;
        static Action<string> ZeroHealthEvent;

        const string LINE_HEALTH = "[*]";
        const int MAX_HEALTH = 3;
        const int CURE = 4;

        static int healthCount = MAX_HEALTH;
        static int currentTime = 0;
        static readonly int lifeTime = 60_000; // время жизни в милисекундах
        static bool notCured = false;

        static void Main(string[] args)
        {
            DrawImage();
            Console.Write("Enter name of your pet: ");
            string petName = Console.ReadLine();
            
            // будем сохранять предыдущую просьбу что бы проверять со следующей и избежать повторений
            int prevRequest = 0;
           
            HealthStatus(petName);

            DecreeseHealthEvent += HealthStatus;
            ZeroHealthEvent += CureMe;

            System.Timers.Timer timer = new System.Timers.Timer { Interval = 3000 };
            timer.Elapsed += (s, e) =>
            {
                currentTime += 3000;

                timer.Enabled = false;

                if (currentTime >= lifeTime || notCured)
                {
                    Console.Write("Your pet has died. ");
                    if (notCured)
                    {
                        Console.WriteLine($"You didn't cure {petName}.");
                    }
                    else
                    {
                        Console.WriteLine($"{petName} is too old.");
                    }
                    timer.Stop();                   
                }
                else
                {
                    // будем передавать по ссылке предыдущую просьбу что бы она каждый раз перезаписывалась
                    PetWants(petName, ref prevRequest);
                    
                    if (healthCount == 0)
                    {
                        ZeroHealthEvent?.Invoke(petName);
                    }
                    timer.Enabled = true;
                }              
            };

            timer.Start();           
            Console.Read();
        }

        private static void MessageBoxShow(string petName, string WhatToDo)
        {        
            var result = MessageBox.Show(WhatToDo, petName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (result)
            {
                case DialogResult.Yes:
                    if (WhatToDo.Equals(requests[CURE])) {                       
                        healthCount = MAX_HEALTH;
                        Console.WriteLine("Pet was cured");
                        HealthStatus(petName);
                    }
                    break;
                case DialogResult.No:
                    if (WhatToDo.Equals(requests[CURE]))
                    {
                        notCured = true;
                    }
                    else
                    {
                        healthCount--;
                        DecreeseHealthEvent?.Invoke(petName);
                    }
                    break;
            }
        }

        public static void PetWants (string petName, ref int prevRequest)
        {
            Random rand = new Random();
            int requestNumber = rand.Next(0, 4);

            while (requestNumber == prevRequest)
            {
                requestNumber  = rand.Next(0, 4);
            }
            
            string WhatToDo = requests[requestNumber];
            MessageBoxShow(petName, WhatToDo);

            // изменим для следующей проверки 
            prevRequest = requestNumber;
        }

        private static void HealthStatus(string petName)
        {
            Console.Write($"Health of {petName}: ");
            for (int i = 0; i < healthCount; i++)
            {
                Console.Write(LINE_HEALTH);
            }

            int healthPercent = 0;
            if (healthCount >= 3)
            {
                healthPercent = 100;
            }
            else if(healthCount == 2)
            {
                healthPercent = 66;
            }
            else if (healthCount == 1)
            {
                healthPercent = 33;
            }

            Console.Write($" {healthPercent}%\n");
        }

        static void CureMe(string petName)
        {
            string WhatToDo = requests[CURE];
            MessageBoxShow(petName, WhatToDo);
        }

        static void DrawImage()
        {
            string image = "_______________________________________$_____$$_\n" +
                           "______________________________________$_ $$_____$\n" +
                           "_____$$$$$____$$$$$$$$____$$$$$$______$$__$$___$ \n" +
                           "___$$_____$_$_________$_$$______$$$$$_____$$___$ \n" +
                           "_$$______$_____________$$$____ ___$___$$$$$___$$_\n" +
                           "$$_____$________________$$$______$_________$$___ \n" +
                           "$_____$___________________$______$___________$__ \n" +
                           "_$$_$$$_____________ ______$_______$___________$_\n" +
                           "_____$$_________$$$$_____$________$___________$_ \n" +
                           "______$_$$$$____$$$$$____$_______$____________$_ \n" +
                           "______$_$$ $$_$$$_$$$__$$___$$$$$______________$_\n" +
                           "_______$$__$$$$$$_______$$$___________________$_ \n" +
                           "______$$____$$$$$_________$______$___________$__ \n" +
                           "_ _____$____$__$____$_____$$____$__$_________$___\n" +
                           "_______$$___$$$$$$$____$$_____$__$$_________$___ \n" +
                           "________$$$$__$$$__$$$$_______$_$________ $$$____\n" +
                           "_________$______$$____________$_$______$$$______ \n" +
                           "________$______$____________$$____$$$$$_________ \n" +
                           "_________$$$$$$$___________$$__ _________________\n" +
                           "________________$$$______$$_____________________ \n" +
                           "__________________$$$$$$________________________\n";
            Console.WriteLine(image);
        }
    }
}
