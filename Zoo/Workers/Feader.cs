using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Feader : NonCleaners
    {
        public Feader(Animal currentAnimal, Areas area, bool isBonus) : base(currentAnimal, area, isBonus)
        {
            workingInterval = 10;
            ticketCost = 100;
        }
    }
}
