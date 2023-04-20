using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public abstract class Animal
    {
        public string Name;
        public Area Area;
        public bool IsBusy;
        public abstract void MakeSound();
    }
}
