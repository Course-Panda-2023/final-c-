using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals.SeaAnimals
{
    public class Shark : SeaAnimal
    {
        public Shark(string Name)
        {
            this.Name = Name;
            this.Area = Area.Sea;
            this.IsBusy = false;
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name}: Ssshhhar!");
        }
    }
}
