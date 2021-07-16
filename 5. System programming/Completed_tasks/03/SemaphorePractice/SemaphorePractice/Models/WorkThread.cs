using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphorePractice.Models
{
    public class WorkThread
    {

        public event Action<WorkThread> StartWait;
        public event Action<WorkThread> StartWork;
        public event Action<WorkThread> Progress;

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;
        ThreadLocker locker = ThreadLocker.Instance;

        Task task;

        public string Name { get; set; }
        public int Value { get; set; }

        public WorkThread()
        {
            Value = 0;
            token = source.Token;
        }
        public void Start()
        {
            task = new Task(Action);
            task.Start();
        }
        private void Action()
        {
            StartWait?.Invoke(this);
            locker.semaphore.WaitOne();
            StartWork?.Invoke(this);

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    try
                    {
                        locker.semaphore.Release();
                    }
                    catch (SemaphoreFullException) { }
                    return;
                }
                Value++;
                Progress?.Invoke(this);
                Thread.Sleep(10);
            }
        }

        public void Cancel()
        {
            source.Cancel();
        }
        public void Restart()
        {
            Start();
        }

        public override string ToString() => $"{Name} -> {Value}";
    }
}
