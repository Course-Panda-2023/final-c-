using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooFinalProject
{
    public class AirAnimal : Animal
    {
        public AirAnimal(string name, string sound, Location location) : base(name, sound, location)
        {
        }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name} makes a sound: {Sound}");
        }
    }



}
