using Zoo.Util.Enum;

namespace Zoo.Model.Animals.Amphibia
{
    internal abstract class AmphiniaAnimal : Animal
    {
        public AmphiniaAnimal()
        {
            GrowingUpZone = ZonesType.AmphibiaZone;
        }
    }
}
