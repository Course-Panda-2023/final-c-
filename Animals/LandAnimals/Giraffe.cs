using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Giraffe : LandAnimals
    {
        public Giraffe(string _name) : base(_name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Giraffe({_name}) : giraffe sounds ");
        }
    }
}
