using Zoo.Utils.Enum;

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
