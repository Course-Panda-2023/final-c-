using Zoo.Utils.EnumTypes;

namespace Zoo.Model.Animals.SeaCreature
{
    internal abstract class SeaCreatureAnimal : Animal
    {
        public SeaCreatureAnimal()
        {
            GrowingUpZone = ZooZonesType.SeaCreatureZone;
        }
    }
}
