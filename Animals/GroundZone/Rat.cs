using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Zoo.Animals.GroundZone
{
    public class Rat : GroundAnimal
    {
        private const string _sound = "squeak squeak";

        public Rat(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
