using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class GoldFish : SeaAnimals
    {
        public GoldFish(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"GoldFish({_name}) : GoldFish sounds ");
        }
    }
}
