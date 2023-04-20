using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Alligator : MixedAnimals
    {
        public Alligator(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Alligator({_name}) : alligator sounds ");
        }
    }
}
