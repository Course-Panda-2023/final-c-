using Zoo.Util.Enum;

namespace Zoo.Model.Animals
{
    internal abstract class Animal
    {
        public string? RaceName { get; init; }

        public string? NickName { get; set; }

        public ZonesType GrowingUpZone { get; protected set; }

        public AnimalType AnimalType { get; protected set; }

        public abstract void MakeSound();
    }
}
