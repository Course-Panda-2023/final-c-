using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Zoo.Animals.AquaticZone
{
    public class Whale : AquaticAnimal
    {
        private const string _sound = "sing";

        public Whale(string name) : base(name)
        {
        }

        public void MakeSound() => Console.WriteLine(_sound);
    }
}
