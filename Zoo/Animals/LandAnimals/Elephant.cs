using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals.LandAnimals
{
    public class Elephant : LandAnimal
    {
        public Elephant(string Name)
        {
            this.Name = Name;
            this.Area = Area.Land;
            this.IsBusy = false;
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{this.Name}: Thewwwwww!");
        }
    }
}
