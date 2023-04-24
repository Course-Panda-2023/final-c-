using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals;

namespace CSharp_Zoo.ZooWorkers
{
    public abstract class ZooWorker
    {
        //public delegate void PatrolHandler(ZooWorker worker, int zone);
        public event EventHandler<WorkerEventArgs> WorkStarted;
        public event EventHandler<WorkerEventArgs> WorkFinished;

        private ZoneTypes _zone;
        private Animal _currentAnimal;
        private TimeSpan _workingTime;

        public  Animal CurrentAnimal { get; set; }
        public  ZoneTypes Zone { get; set; }
        public abstract int WorkingTime();
        public abstract ZooPositions GetPosition();
        public abstract void TreatAnimal();

        protected virtual void OnWorkStarted()
        {
            WorkStarted?.Invoke(this, new WorkerEventArgs(this, DateTime.Now));
        }
        protected virtual void OnWorkFinished()
        {
            WorkFinished?.Invoke(this, new WorkerEventArgs(this, DateTime.Now));
        }


    }
    public class WorkerEventArgs : EventArgs
    {
        public ZooWorker Worker { get; set; }
        public DateTime Timestamp { get; set; }

        public WorkerEventArgs(ZooWorker worker, DateTime timestamp)
        {
            Worker = worker;
            Timestamp = timestamp;
        }
    }
}
