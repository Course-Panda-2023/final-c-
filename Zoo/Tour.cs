using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Tour
    {
        const int tourInterval = 10;
        static ZooManager Manager = ZooManager.Instance;

        private Areas area;
        private int tourTime;
        private int pauseTime;
        private bool isPaused;
        private bool isDone;
        private Worker thePauser;
        private int id;
        private static readonly EventWaitHandle resetEvent = new ManualResetEvent(initialState: true);
        //private ManualResetEvent resetEvent = new ManualResetEvent(false);


        public Areas Area { get { return area; } }
        public bool IsPaused { get { return isPaused; } }
        public bool IsDone { get { return isDone; } }
        public Worker ThePauser { get { return thePauser; } }

        public Tour(Areas area, int startTime, int id)
        {
            this.area = area;
            tourTime = startTime;
            pauseTime = 0;
            isPaused = false;
            isDone = false;
            Thread t = new Thread(StartTour);
            t.Start();
            thePauser = null;
            this.id = id;
        }

        public void StartTour()
        {
            Manager.LogEvents($"Tour {id} started in area {area} at time: {tourTime}.");
            for(int i = 0; i < tourInterval; i++)
            {
                //this.resetEvent.WaitOne(Timeout.Infinite);
                resetEvent.WaitOne();
                Thread.Sleep(100);
                //Console.WriteLine($"\nTour {id} {tourTime + i} || {MainZoo.time}.");
            }
            Manager.LogEvents($"Tour {id} ended in area {area} at time: {tourTime + 10} || {MainZoo.time}.");
            isDone = true;
        }

        public void PauseTour(int pauseTime, Worker pauser)
        {
            Manager.LogEvents($"Tour {id} paused in area {area}.");
            isPaused = true;
            this.pauseTime = pauseTime;
            thePauser = pauser;
            resetEvent.Reset();
        }

        public void ResumeTour(int resumeTime)
        {
            Manager.LogEvents($"Tour {id} resumed in area {area}.");
            isPaused = false;
            tourTime += (resumeTime - pauseTime);
            resetEvent.Set();
        }
    }
}
