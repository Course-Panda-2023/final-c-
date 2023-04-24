using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Cleaner : Worker
    {
        public Cleaner(Areas area, bool isBonus) : base(area, isBonus)
        {
            workingInterval = 2;
            ticketCost = 30;
        }
    }
}
