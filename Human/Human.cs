using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class Human
    {
        protected string _name;
        public string Name { get { return _name; } }    

        protected Human (string name)
        {
            _name = name;
        }   
    }
}
