using Zoo.Utils.Enum;

namespace Zoo.Model.Animals
{
    internal abstract class Animal
    {
        public string? RaceName { get; init; }

        public string? NickName { get; set; }

        public ZooZonesType GrowingUpZone { get; protected set; }

        public ZooAnimalType AnimalType { get; protected set; }

        public abstract void MakeSound();
    }
}
