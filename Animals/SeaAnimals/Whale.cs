using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Whale : SeaAnimals
    {
        public Whale(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Whale({_name}) : whale sounds ");
        }
    }
}
