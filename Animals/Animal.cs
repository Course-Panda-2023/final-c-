using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class Animal
    {
        protected ZoneType _zoneType;
        protected bool _beingTreated;
        public ZoneType zoneType { get { return _zoneType; } }  
        public bool beingTrated { get { return _beingTreated; }  set { _beingTreated = value; }  }

        protected string _name;

        public Animal(string name)
        {
            _name = name;
        }
        public abstract void MakeSound();
    }
}
