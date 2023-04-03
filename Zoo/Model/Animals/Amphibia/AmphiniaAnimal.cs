﻿using Zoo.Utils.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal abstract class AmphiniaAnimal : Animal
    {
        public AmphiniaAnimal()
        {
            GrowingUpZone = ZooZonesType.AmphibiaZone;
        }
    }
}
