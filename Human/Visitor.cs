using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Visitor : Human
    {
        private bool _inATour;
        public bool inATour { get { return _inATour;  }  set { _inATour = value; } }

        public Visitor(string name) : base(name)
        {
            _inATour = false;
        }
    }
}
