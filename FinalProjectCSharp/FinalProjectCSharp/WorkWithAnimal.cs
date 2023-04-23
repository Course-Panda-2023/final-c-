using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class WorkWithAnimal : ZooWorker
    {
        protected Animal _workOnAnimal;
        protected string _action;
        public Animal WorkOnAnimal { get { return _workOnAnimal; } }

        public WorkWithAnimal(String name, Area workArea) : base(name, workArea)
        {
            _workOnAnimal = null;
        }

        public void AddAnimalWorkOn(Animal animal)
        {
            if (_workOnAnimal == null)
            {
                Console.WriteLine($"{_name} is start {_action} {animal.AnimalName}");
                _workOnAnimal = animal;
            }
        }

        public string FinishedWorkWithAnimal()
        {
            if (_workOnAnimal != null)
            {
                _workOnAnimal = null;
                return $"{_name} is finish {_action} {_workOnAnimal.AnimalName}";
            }
            return "";
        }
    }
}
