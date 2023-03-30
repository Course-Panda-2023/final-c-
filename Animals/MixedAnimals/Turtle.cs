using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Turtle : MixedAnimals
    {
        public Turtle(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Turtle({_name}) : Turtle sounds ");
        }
    }
}
