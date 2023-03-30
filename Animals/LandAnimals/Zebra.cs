using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Zebra : LandAnimals
    {
        public Zebra(string _name) : base(_name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Zebra({_name}) : zebra sounds ");
        }
    }
}
