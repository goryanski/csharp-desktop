using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipsPractice.Models
{
    public class WorkShip
    {
        static Semaphore semaphore = new Semaphore(5, 5);
        static Mutex mutexBread = new Mutex();
        static Mutex mutexBanana = new Mutex();
        static Mutex mutexCloth = new Mutex();


        public event Action<WorkShip> ShipEntersTheTunnel;
        public event Action<WorkShip> ShipBreadGoesToStock;
        public event Action<WorkShip> ShipBananaGoesToStock;
        public event Action<WorkShip> ShipClothGoesToStock;
        public event Action<WorkShip> ShipGoesFromTunnel;

        public string Product { get; set; }
        public int Сapacity { get; set; }

        Task task;

        public WorkShip() { }

        public void Start()
        {
            task = Task.Run(() =>
            {
                semaphore.WaitOne();
                ShipEntersTheTunnel?.Invoke(this);

                int usedMutex = 0;
                switch (Product)
                {
                    case "Bread":
                        mutexBread.WaitOne();
                        ShipBreadGoesToStock?.Invoke(this);
                        usedMutex = 1;
                        break;
                    case "Banana":
                        mutexBanana.WaitOne();
                        ShipBananaGoesToStock?.Invoke(this);
                        usedMutex = 2;
                        break;
                    case "Cloth":
                        mutexCloth.WaitOne();
                        ShipClothGoesToStock?.Invoke(this);
                        usedMutex = 3;
                        break;
                }

                ShipGoesFromTunnel?.Invoke(this);
                semaphore.Release();
                Thread.Sleep(1000);

                if(usedMutex == 1) mutexBread.ReleaseMutex();
                if(usedMutex == 2) mutexBanana.ReleaseMutex();
                if(usedMutex == 3) mutexCloth.ReleaseMutex();
            });
        }

        public override string ToString() => $"{Product}Ship {Сapacity}";
    }
}
