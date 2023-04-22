using CSharp_Zoo.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.ZooWorkers
{
    public class Feeder : ZooWorker
    {
        private const int _workingTime = 10;
        

        public override int WorkingTime() => _workingTime;
        public override ZooPositions GetPosition() => ZooPositions.Feeder;

        public override void TreatAnimal()
        {
            if (CurrentAnimal.WorkedBy == null)
            {
                CurrentAnimal.WorkedBy = this;
                OnWorkStarted();
                //Treating...
                Thread.Sleep(300);
                Console.WriteLine("Treated");
                CurrentAnimal.WorkedBy = null;
                OnWorkFinished();
            }
            else
            {
                Console.WriteLine("Animal is already being worked on.");
            }
        }

    }
}
