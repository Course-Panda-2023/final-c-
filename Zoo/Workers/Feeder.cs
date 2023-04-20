using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Workers
{
    public class Feeder : Worker
    {
        private Animal Animal;
        public Feeder(string name, Animal animal) : base(name)
        {
            Animal = animal;
            this.WorkArea = Animal.Area;
            this.WorkTime = 10;
        }
        public override void DoWork()
        {
            Console.WriteLine("Feeding!");
            Console.WriteLine("Done feeding.");
        }
    }
}
