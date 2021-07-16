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
using SemaphorePractice.Models;

namespace SemaphorePractice
{
    public partial class Form1 : Form
    {
        List<WorkThread> workingThreads = new List<WorkThread>();
        List<WorkThread> waitingThreads = new List<WorkThread>();
        List<WorkThread> createdThreads = new List<WorkThread>();

        int countPlaces = 3;
        int counterValues = 1;

        public Form1()
        {
            InitializeComponent();
            InitNud();
        }

        private void InitNud()
        {
            nudCountPlaces.Value = countPlaces;
        }

        private void BtnCreateThread_Click(object sender, EventArgs e)
        {
            WorkThread workThread = new WorkThread { Name = $"Tread {counterValues++}" };
            Subscribe(workThread);
            createdThreads.Add(workThread);
            UpdateListCreatedThreads();
        }

        private void Subscribe(WorkThread workThread)
        {
            workThread.StartWait += (t) =>
            {
                int idx = createdThreads.IndexOf(t);
                waitingThreads.Add(t);
                UpdateListWaitingThreads();
                createdThreads.Remove(t);
                UpdateListCreatedThreads();
            };
            workThread.StartWork += (t) =>
            {
                
                int idx = waitingThreads.IndexOf(t);
                workingThreads.Add(t);
                UpdateListWorkingThreads();
                waitingThreads.Remove(t);
                UpdateListWaitingThreads();
            };
            workThread.Progress += (t) =>
            {
                UpdateListWorkingThreads();
            };
        }

        #region Lists updates
        private void UpdateListCreatedThreads()
        {
            BeginInvoke(new Action(() =>
            {
                lbCreatedThreads.DataSource = null;
                lbCreatedThreads.DataSource = createdThreads;
            }));
        }
        private void UpdateListWorkingThreads()
        {
            BeginInvoke(new Action(() =>
            {
                lbRunningThreads.DataSource = null;
                lbRunningThreads.DataSource = workingThreads;
            }));
        }

        private void UpdateListWaitingThreads()
        {
            BeginInvoke(new Action(() =>
            {
                lbWaitingThreads.DataSource = null;
                lbWaitingThreads.DataSource = waitingThreads;
            }));
        }
        #endregion

        private void LbRunningThreads_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selIdx = lbRunningThreads.SelectedIndex;
            if (selIdx != -1)
            {
                WorkThread wt = workingThreads[selIdx];
                wt.Cancel();

                workingThreads.Remove(wt);
                UpdateListWorkingThreads();
            }
        }

        private void LbCreatedThreads_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selIdx = lbCreatedThreads.SelectedIndex;
            if (selIdx != -1)
            {
                WorkThread wt = createdThreads[selIdx];
                wt.Start();
            }
        }

        private void NudCountPlaces_ValueChanged(object sender, EventArgs e)
        {
            countPlaces = Convert.ToInt32(nudCountPlaces.Value);

            foreach (var t in workingThreads)
            {
                t.Cancel();
            }
            foreach (var t in waitingThreads)
            {
                t.Cancel();
            }

            ThreadLocker.Instance.SetCountPlaces(countPlaces);

            Task.Run(() =>
            {
                Thread.Sleep(50);

                var restartThreadValues = new List<Tuple<string, int>>();
                workingThreads.ForEach(t => restartThreadValues.Add(new Tuple<string, int>(t.Name, t.Value)));
                waitingThreads.ForEach(t => restartThreadValues.Add(new Tuple<string, int>(t.Name, t.Value)));


                foreach (var t in restartThreadValues)
                {
                    var wt = new WorkThread { Name = t.Item1, Value = t.Item2 };
                    Subscribe(wt);
                    wt.Start();
                }
                workingThreads.Clear();
                waitingThreads.Clear();
            });
        }
    }
}
