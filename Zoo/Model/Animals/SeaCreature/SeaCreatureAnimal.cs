using Zoo.Utils.Enum;

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
