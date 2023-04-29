using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Zoo.Animals.MixedZone
{
    public class Hippopotamus : MixedAnimal
    {
        private const string _sound = "grunt grunt";

        public Hippopotamus(string name) : base(name)
        {
        }
        public override void MakeSound() => Console.WriteLine(_sound);
    }
}
