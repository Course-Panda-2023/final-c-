using Zoo.Model.Animals.Amphibia;
using Zoo.Model.Animals.Bird;
using Zoo.Model.Animals.Land;
using Zoo.Model.Animals.SeaCreature;
using Zoo.Model.Animals;
using Zoo.ZooRelated;

namespace Zoo.Test.Section1
{
    internal class IntegrationTest
    {
        public void ExecuteTest()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Alligator() { RaceName = "Aligator" },
                new Duck() { RaceName = "Duck" },
                new Frog() { RaceName = "Frog" },
                new Hipo() { RaceName = "Hipo" },
                new Turtle() { RaceName = "Turtle" },
                new Eagle() { RaceName = "Eagle" },
                new Hawk() { RaceName = "Hawk" },
                new Owl() { RaceName = "Owl" },
                new Pelican() { RaceName = "Pelican" },
                new Vulture() { RaceName = "Vulture" },
                new Elephant() { RaceName = "Elephant" },
                new Giraffe() { RaceName = "Giraffe" },
                new Kangaroo() { RaceName = "Kangaroo" },
                new Lion() { RaceName = "Lion" },
                new Zebra() { RaceName = "Zebra" },
                new Dolphin() { RaceName = "Dolphin" },
                new GoldFish() { RaceName = "GoldFish" },
                new PufferFish() { RaceName = "Pufferfish" },
                new Shark() { RaceName = "Shark" },
                new Whale() { RaceName = "Whale" },
            };

            ZooZone ZooZoneInstance = new(animals);

            ZooZoneInstance.MessInZooAllAnimals();
        }
    }
}
