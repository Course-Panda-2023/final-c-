using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Lion : LandAnimals
    {
        public Lion(string _name) : base(_name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Lion({_name}) : lion sounds ");
        }
    }
}
