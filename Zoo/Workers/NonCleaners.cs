using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class NonCleaners : Worker
    {
        protected Animal currentAnimal;
        public Animal CurrentAnimal { get { return currentAnimal; } set { currentAnimal = value; } }

        protected NonCleaners(Animal currentAnimal, Areas area, bool isBonus) : base(area, isBonus)
        {
            this.currentAnimal = currentAnimal;
        }
    }
}
