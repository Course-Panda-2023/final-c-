using Zoo.Util.Enum;

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
