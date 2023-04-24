using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals.AerialZone
{
    public class Parrot : AerialAnimal
    {
        private const string _sound = "squawk squawk";

        public Parrot(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
