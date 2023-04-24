using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Kangaroo : LandAnimals
    {
        public Kangaroo(string _name) : base(_name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Kangaroo({_name}) : kangaroo sounds ");
        }
    }
}
