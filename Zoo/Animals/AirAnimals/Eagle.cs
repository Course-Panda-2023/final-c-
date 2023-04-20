using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals.AirAnimals
{
    public class Eagle : AirAnimal
    {
        public Eagle(string Name)
        {
            this.Name = Name;
            this.Area = Area.Air;
            this.IsBusy = false;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name}: Pewpew!");
        }
    }
}
