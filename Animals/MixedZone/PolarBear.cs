using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals.AerialZone;

namespace CSharp_Zoo.Animals.MixedZone
{
    public class PolarBear : MixedAnimal
    {
        private const string _sound = "growl growl";

        public PolarBear(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
