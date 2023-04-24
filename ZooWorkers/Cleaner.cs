using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals;

namespace CSharp_Zoo.ZooWorkers
{
    public class Cleaner : ZooWorker
    {
        private const int _workingTime = 2;

        public override int WorkingTime() => _workingTime;
        public override ZooPositions GetPosition() => ZooPositions.Cleaner;

        public override void TreatAnimal()
        {
            return;
        }
    }
}
