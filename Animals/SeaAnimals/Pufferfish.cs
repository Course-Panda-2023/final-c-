﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Pufferfish : SeaAnimals
    {
        public Pufferfish(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Manager.Instance.WriteToFile($"Pufferfish({_name}) : pufferfish sounds ");
        }
    }
}
