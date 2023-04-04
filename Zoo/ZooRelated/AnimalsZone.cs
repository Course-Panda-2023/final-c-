using System.Runtime.InteropServices;
using Zoo.Model.Animals;
using Zoo.Util.Enum;
using Zoo.Util.CustomException;

namespace Zoo.ZooRelated
{
    internal class AnimalsZone
    {
        public string? Name { get; set; }

        public string? Location { get; set; }

        public ZonesType Type { get; }


        public List<Animal>? Animals;


        public AnimalsZone(List<Animal> animals)
        {
            CheckIfAnimalsAreDistinct(animals);

            CheckIfForEachZoneMoreAtLeastThreeAnimals(animals);

            CheckIfAnimalRelatedToThisZone(animals);

            Animals = animals;
        }

        public AnimalsZone(List<Animal> animals, ZonesType type)
        {
            CheckIfAnimalsAreDistinct(animals);

            CheckIfForEachZoneMoreAtLeastThreeAnimals(animals);

            CheckIfAnimalRelatedToThisZone(animals);

            Animals = animals;

            Type = type;
        }

        private void CheckIfThereAreTwoOrMoreAnimals(List<Animal> animals, Animal Animal)
        {
            int CountApperances = CountAnimalTypeInAnimals(animals, Animal.AnimalType);
            if (CountApperances >= 2)
            {
                throw new TwoOrMoreAnimalsFromTheSameTypeException($"There are {CountApperances} from type of {Animal.RaceName}");
            }
        }

        // Note: Not related to this class but needed here
        private int CountAnimalTypeInAnimals(List<Animal> animals, AnimalType AnimalType)
        {
            return animals.Count(animalLinq => animalLinq.AnimalType == AnimalType);
        }

        private void CheckIfAnimalsAreDistinct(List<Animal> animals)
        {
            foreach (Animal? animal in CollectionsMarshal.AsSpan(animals))
            {
                CheckIfThereAreTwoOrMoreAnimals(animals, animal);
            }
        }

        private void CheckIfForEachZoneMoreAtLeastThreeAnimals(List<Animal> animals)
        {
            Dictionary<ZonesType, List<Animal>> ZoneAndItsAnimals = GetAnimalsInZone(animals);

            foreach (ZonesType zoneType in ZoneAndItsAnimals.Keys)
            {
                int ZoneCount = ZoneAndItsAnimals[zoneType].Count;
                if (ZoneCount < 3)
                {
                    throw new LessThanTwoAnimalsInCertainZoneException($"There are {ZoneCount} in zone {zoneType}");
                }
            }
        }

        private void CheckIfAnimalRelatedToThisZone(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                if (animal.GrowingUpZone == Type)
                {
                    throw new AnimalDoesNotRelatedToException($"Animal from Race {animal.RaceName} are not related to zon {Type}" +
                        $"its zone is {animal.GrowingUpZone}");
                }
            }
        }


        public void MessInZooAllAnimals()
        {
            foreach (Animal? animal in CollectionsMarshal.AsSpan(Animals))
            {
                animal.MakeSound();
            }
        }

        public Dictionary<ZonesType, List<Animal>> GetAnimalsInZone(List<Animal> animals)
        {
            return animals.GroupBy(animal => animal.GrowingUpZone).ToDictionary(animal => animal.Key, animal => animal.ToList());
        }
    }
}
