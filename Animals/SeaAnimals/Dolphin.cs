using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Dolphin : SeaAnimals
    {
        public Dolphin(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Dolphin({_name}) : dolphin sounds ");
        }
    }
}
