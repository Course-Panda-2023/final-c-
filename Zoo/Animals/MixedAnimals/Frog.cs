using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals.MixedAnimals
{
    public class Frog : MixedAnimal
    {
        public Frog(string Name)
        {
            this.Name = Name;
            this.Area = Area.Mix;
            this.IsBusy = false;
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name}: QrackQrack");
        }
    }
}
