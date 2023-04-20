using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Workers
{
    public class Doctor : Worker
    {
        private Animal Animal;

        public Doctor(string name, Animal animal) : base(name)
        {
            Animal = animal;
            this.WorkArea = Animal.Area;
            this.WorkTime = 5;
        }

        public override void DoWork()
        {
            Console.WriteLine("Healing!");
            Thread.Sleep(WorkTime * 1000);
            Console.WriteLine("Done healing.");
        }
    }
}
