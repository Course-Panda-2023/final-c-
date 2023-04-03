using Zoo.Model.Animals;
using Zoo.Model.Animals.Amphibia;
using Zoo.Model.Animals.Bird;
using Zoo.Model.Animals.Land;
using Zoo.Model.Animals.SeaCreature;
using Zoo.Model.Employee;
using Zoo.Tour;
using Zoo.Utils.Enum;
using Zoo.ZooRelated;

namespace Zoo.Test.Section2
{
    internal class IntegrationTest
    {
        public Dictionary<ZooZonesType, List<Animal>> GetAnimalsInZone(List<Animal> animals)
        {
            return animals.GroupBy(animal => animal.GrowingUpZone).ToDictionary(animal => animal.Key, animal => animal.ToList());
        }

        public void ExecuteTest()
        {
            EventLogger.EventLogger eventLogger = new();

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

            var regionAndItsAnimals = GetAnimalsInZone(animals);

            List<ZooZone> zones = regionAndItsAnimals.Select(region => new ZooZone(region.Value, region.Key)).ToList();
            ZooHandler zooHandler = new
            (
                zones,
                new List<Employee>()
                {
                    new Doctor("Assaf The Doc")
                    {
                        Name = "Assaf",
                        CurrentWorkingZone = ZooZonesType.BirdZone,
                    },
                    new Cleaner("Raz the employee")
                    {
                        Name = "Raz",
                        CurrentWorkingZone = ZooZonesType.AmphibiaZone,
                    },
                    new Feeder("Amit the Tal")
                    {
                        Name = "Amir",
                        CurrentWorkingZone = ZooZonesType.OrdinaryLandZone
                    },
                    new Feeder("Guy the coder")
                    {
                        Name = "Guy",
                        CurrentWorkingZone = ZooZonesType.SeaCreatureZone
                    },
                    new Feeder("Eyal the nice")
                    {
                        Name = "Eyal",
                        CurrentWorkingZone = ZooZonesType.OrdinaryLandZone
                    },
                    new Doctor("Liav")
                    {
                        Name = "Liav",
                        CurrentWorkingZone = ZooZonesType.SeaCreatureZone
                    }
                },
                new List<TourOrTwoTours>
                {
                    new TourOrTwoTours(new List<TourPlace>()
                    {
                        new TourPlace(ZooZonesType.OrdinaryLandZone),
                        new TourPlace(ZooZonesType.AmphibiaZone)
                    }),

                    new TourOrTwoTours(new List<TourPlace>()
                    {
                        new TourPlace(ZooZonesType.SeaCreatureZone),
                    }),

                    new TourOrTwoTours(new List<TourPlace>()
                    {
                        new TourPlace(ZooZonesType.BirdZone),
                    }),
                    new TourOrTwoTours(new List<TourPlace>()
                    {
                        new TourPlace(ZooZonesType.AmphibiaZone),
                        new TourPlace(ZooZonesType.BirdZone)
                    }),
                    new TourOrTwoTours(new List<TourPlace>()
                    {
                        new TourPlace(ZooZonesType.AmphibiaZone),
                    })
                },
                new List<Visitor>()
                {
                    new Visitor("Mike")
                    {
                        Name = "Mike"
                    },
                    new Visitor("Angella")
                    {
                        Name = "Angella"
                    },
                    new Visitor("Hoku")
                    {
                        Name = "Hoku"
                    },
                    new Visitor("Picolo")
                    {
                        Name = "Picolo"
                    },
                    new Visitor("Vegeta")
                    {
                        Name = "Vegeta"
                    },
                    new Visitor("Trunks")
                    {
                        Name = "Trunks"
                    },
                    new Visitor("PackMan")
                    {
                        Name = "PackMan"
                    },
                    new Visitor("OOP")
                    {
                        Name = "OOP"
                    },
                    new Visitor("Paul")
                    {
                        Name = "Paul"
                    },
                    new Visitor("Robbin")
                    {
                        Name = "Robbin"
                    },
                    new Visitor("Shaw")
                    {
                        Name = "Shaw"
                    },
                    new Visitor("Jin")
                    {
                        Name = "Jin"
                    },
                    new Visitor("Asuka")
                    {
                        Name = "Asuka"
                    },
                    new Visitor("Peter Parker")
                    {
                        Name = "Peter Parker"
                    },
                    new Visitor("John Wall")
                    {
                        Name = "John Wall"
                    },
                    new Visitor("John Wick")
                    {
                        Name = "John Wick"
                    },
                }



            );

            zooHandler.RunAllTours();
        }
    }
}
