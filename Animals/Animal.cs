using CSharp_Zoo.ZooWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Zoo.Animals
{
    public abstract class Animal
    {
        private readonly string _name;
        private bool isAvailable = true;
        private ZooWorker _workedBy;
        public Animal(string name)
        {
            _name = name;
        }

        public ZooWorker WorkedBy { get; set; }
        public bool IsAvailable { get; set; }
        public string Name => _name;
        public abstract ZoneTypes GetZone();

        
        public abstract void MakeSound();
    }
}
