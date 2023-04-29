using CSharp_Zoo.Animals;
using CSharp_Zoo.Zoo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.ZooWorkers
{
    public class Doctor : ZooWorker
    {
        private const int _workingTime = 500; //ms

        public override void TreatAnimal()
        {
            //var animalsInZone = _zoo.Animals.Where(a => a.Zone == Zone).ToList();
            /*if (CurrentAnimal == null)
            {
                Console.WriteLine("Ne s kem govoriti!");
                return;
            }*/

            if (CurrentAnimal.WorkedBy == null)
            {
                CurrentAnimal.WorkedBy = this;
                OnWorkStarted();
                //Treating...
                Thread.Sleep(_workingTime);
                Console.WriteLine("Treated");
                CurrentAnimal.WorkedBy = null;
                OnWorkFinished();
            }
            else
            {
                Console.WriteLine("Animal is already being worked on.");
            }
            
        }
        public override int WorkingTime() => _workingTime;
        public override ZooPositions GetPosition() => ZooPositions.Doctor;
    }
}

