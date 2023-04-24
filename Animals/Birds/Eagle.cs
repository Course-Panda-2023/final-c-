using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Eagle : Birds
    {
        public Eagle(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Eagle({_name}) : eagle sounds ");
        }
    }
}
