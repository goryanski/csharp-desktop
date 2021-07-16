using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphorePractice.Models
{
    public class ThreadLocker
    {
        int countPlaces = 3;
        public Semaphore semaphore;

        public static ThreadLocker Instance { get; private set; } = new ThreadLocker();

        private ThreadLocker() { }

        public void SetCountPlaces(int val)
        {
            countPlaces = val;
            if (semaphore != null)
            {
                semaphore.Close();
            }
            semaphore = CreateSemaphore();
        }

        private Semaphore CreateSemaphore() => new Semaphore(countPlaces, countPlaces);
    }
}
