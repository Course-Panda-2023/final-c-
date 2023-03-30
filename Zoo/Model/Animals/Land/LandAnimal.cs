using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Land
{
    internal abstract class LandAnimal : Animal
    {
        public LandAnimal()
        {
            GrowingUpZone = ZooZonesType.OrdinaryLandZone;
        }
    }
}
