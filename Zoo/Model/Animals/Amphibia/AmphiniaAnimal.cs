using Zoo.Utils.EnumTypes;

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
