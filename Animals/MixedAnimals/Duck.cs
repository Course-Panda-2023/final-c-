using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Duck : MixedAnimals
    {
        public Duck(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Duck({_name}) : duck sounds ");
        }
    }
}
