using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Elephant : LandAnimals
    {
        public Elephant(string _name) : base(_name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Elephant({_name}) : elephant sounds ");
        }
    }
}
