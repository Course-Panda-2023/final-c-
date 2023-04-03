using System.Runtime.InteropServices;
using Zoo.Model.Animals;
using Zoo.Utils.CustomException;
using Zoo.Utils.Enum;
using Zoo.ZooUtils.CustomException;

namespace Zoo.ZooRelated
{
    internal class ZooZone
    {
        public string? Name { get; set; }

        public string? Location { get; set; }

        public ZooZonesType type { get; }


        public List<Animal>? Animals;


        public ZooZone(ZooZonesType type)
        {
            this.type = type;
        }

        private void CheckIfThereAreTwoOrMoreAnimals(List<Animal> animals, Animal Animal)
        {
            int CountApperances = CountAnimalTypeInAnimals(animals, Animal.AnimalType);
            if (CountApperances >= 2)
                throw new TwoOrMoreAnimalsFromTheSameTypeException($"There are {CountApperances} from type of {Animal.RaceName}");

        }

        // Note: Not related to this class but needed here
        private int CountAnimalTypeInAnimals(List<Animal> animals, ZooAnimalType AnimalType)
        {
            return animals.Count(animalLinq => animalLinq.AnimalType == AnimalType);
        }

        private void CheckIfAnimalsAreDistinct(List<Animal> animals)
        {
            foreach (var animal in CollectionsMarshal.AsSpan(animals))
            {
                CheckIfThereAreTwoOrMoreAnimals(animals, animal);
            }
        }

        private void CheckIfForEachZoneMoreAtLeastThreeAnimals(List<Animal> animals)
        {
            var ZoneAndItsAnimals = GetAnimalsInZone(animals);

            foreach (var zoneType in ZoneAndItsAnimals.Keys)
            {
                int ZoneCount = ZoneAndItsAnimals[zoneType].Count;
                if (ZoneCount < 3)
                    throw new LessThanTwoAnimalsInCertainZoneException($"There are {ZoneCount} in zone {zoneType}");
            }
        }

        private void CheckIfAnimalRelatedToThisZone(List<Animal> animals)
        {
            foreach(var animal in animals)
            {
                if (animal.GrowingUpZone == type)
                    throw new AnimalDoesNotRelatedToException($"Animal from Race {animal.RaceName} are not related to zon {type}" +
                        $"its zone is {animal.GrowingUpZone}");
            }
        }

        public ZooZone(List<Animal> animals)
        {
            CheckIfAnimalsAreDistinct(animals);

            CheckIfForEachZoneMoreAtLeastThreeAnimals(animals);

            CheckIfAnimalRelatedToThisZone(animals);

            Animals = animals;
        }

        public ZooZone(List<Animal> animals, ZooZonesType type)
        {
            CheckIfAnimalsAreDistinct(animals);

            CheckIfForEachZoneMoreAtLeastThreeAnimals(animals);

            CheckIfAnimalRelatedToThisZone(animals);

            Animals = animals;

            this.type = type;
        }

        public void MessInZooAllAnimals()
        {
            foreach (var animal in CollectionsMarshal.AsSpan(Animals))
            {
                animal.MakeSound();
            }
        }

        public Dictionary<ZooZonesType, List<Animal>> GetAnimalsInZone(List<Animal> animals)
        {
            return animals.GroupBy(animal => animal.GrowingUpZone).ToDictionary(animal => animal.Key, animal => animal.ToList());
        }
    }
}
