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
        public delegate void PatrolHandler(ZooWorker worker, int zone);
        public event PatrolHandler OnStartPatrol;
        public event PatrolHandler OnFinishPatrol;

        private ZoneTypes _zone;
        private Animal _currentAnimal;
        private TimeSpan _workingTime;

        public  Animal CurrentAnimal { get; set; }
        public  ZoneTypes Zone { get; set; }
        public abstract int WorkingTime();
        public abstract ZooPositions GetPosition();
        public abstract void TreatAnimal(Animal animal);

        public void StartPatrol(int zone)
        {
            OnStartPatrol?.Invoke(this, zone);
        }

        public void FinishPatrol(int zone)
        {
            OnFinishPatrol?.Invoke(this, zone);
        }
    }
}
