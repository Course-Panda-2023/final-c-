using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private string sound;
        private bool isTreated;
        protected Areas areas;

        public string Name { get { return name; } }
        public string Sound { get; set; }
        public bool IsTreated { get; set; }
        public Areas Areas { get { return areas; } }

        public Animal(string name)
        {
            this.name = name;
            isTreated = false;
        }

        public void MakeSound()
        {
            Console.WriteLine($"Animal {name} made sound {sound}.");
        }
    }
}
