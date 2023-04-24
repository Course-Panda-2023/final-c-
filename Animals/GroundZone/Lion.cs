using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Zoo.Animals.AerialZone;

namespace CSharp_Zoo.Animals.GroundZone
{
    public class Lion : GroundAnimal
    {
        private const string _sound = "roar roar";

        public Lion(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
