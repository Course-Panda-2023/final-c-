using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals.AerialZone;

namespace CSharp_Zoo.Animals.AquaticZone
{
    internal class Dolphin : AquaticAnimal
    {
        private const string _sound = "whistle";

        public Dolphin(string name) : base(name)
        {
        }

        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
