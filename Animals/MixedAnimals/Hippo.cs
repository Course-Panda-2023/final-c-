using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Hippo : MixedAnimals
    {
        public Hippo(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Hippo({_name}) : hippo sounds ");
        }
    }
}
