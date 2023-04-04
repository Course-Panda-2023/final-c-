using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal abstract class SeaCreatureAnimal : Animal
    {
        public SeaCreatureAnimal()
        {
            GrowingUpZone = ZonesType.SeaCreatureZone;
        }
    }
}
