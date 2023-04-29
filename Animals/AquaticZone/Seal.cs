using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Zoo.Animals.AquaticZone
{
    public class Seal : AquaticAnimal
    {
        private const string _sound = "bark";

        public Seal(string name) : base(name)
        {
        }

        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
