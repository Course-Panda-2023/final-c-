using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.Workers
{
    public class Cleaner : Worker
    {
        public Cleaner(string name, Area WorkArea) : base(name)
        {
            this.WorkArea = WorkArea;
            this.WorkTime = 2;
        }

        public override void DoWork()
        {
            Console.WriteLine("Cleaning!");
            Thread.Sleep(WorkTime * 1000);
            Console.WriteLine("Done cleaning.");
        }
    }
}
