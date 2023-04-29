using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Zoo.Animals.MixedZone
{
    public class Crocodile : MixedAnimal
    {
        private const string _sound = "Hiss hiss";

        public Crocodile(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
