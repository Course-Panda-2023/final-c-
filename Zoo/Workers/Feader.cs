using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Feader : NonCleaners
    {
        public Feader(Animal currentAnimal, Areas area) : base(currentAnimal, area)
        {
            workingInterval = 10;
        }
    }
}
