using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Doctor : NonCleaners
    {
        public Doctor(Animal currentAnimal, Areas area, bool isBonus) : base(currentAnimal, area, isBonus)
        {
            workingInterval = 5;
            ticketCost = 20;
        }
    }
}
