using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.Bird
{
    internal abstract class BirdAnimal : Animal
    {
        public BirdAnimal()
        {
            GrowingUpZone = ZooZonesType.BirdZone;
        }
    }
}
