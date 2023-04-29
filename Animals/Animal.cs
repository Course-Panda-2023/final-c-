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
        private bool isAvailable;
        private ZooWorker _workedBy;
        private ZoneTypes _zone;
        public Animal(string name, ZoneTypes zone)
        {
            _name = name;
            _zone = zone;
            isAvailable = true;
        }
        public ZoneTypes Zone { get => _zone; set => _zone = value; }
        public ZooWorker WorkedBy { get; set; }
        public bool IsAvailable { get; set; }
        public string Name => _name;


        public abstract void MakeSound();
    }
}
