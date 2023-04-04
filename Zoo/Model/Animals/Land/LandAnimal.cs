using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Land
{
    internal abstract class LandAnimal : Animal
    {
        public LandAnimal()
        {
            GrowingUpZone = ZonesType.OrdinaryLandZone;
        }
    }
}
