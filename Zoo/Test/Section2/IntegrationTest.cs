using Zoo.Model.Animals;
using Zoo.Model.Animals.Amphibia;
using Zoo.Model.Animals.Bird;
using Zoo.Model.Animals.Land;
using Zoo.Model.Animals.SeaCreature;
using Zoo.Model.Employee;
using Zoo.Tour;
using Zoo.Util.Enum;
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
            Dictionary<ZooZonesType, List<Animal>> regionAndItsAnimals = GetAnimalsZone();

            ApplicationConstants ApplicationConstantsDependencyInjection = new();
            List<AnimalsZone> zones = regionAndItsAnimals.Select(region => new AnimalsZone(region.Value, region.Key)).ToList();
            List<Visitor> Visitors = new()
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
            };
            List<TourOrTwoToursParallel> Tours = new()
            {
                new TourOrTwoToursParallel(new List<TourPlace>()
                {
                    new TourPlace(ZooZonesType.OrdinaryLandZone),
                    new TourPlace(ZooZonesType.AmphibiaZone)
                }),

                new TourOrTwoToursParallel(new List<TourPlace>()
                {
                    new TourPlace(ZooZonesType.SeaCreatureZone),
                }),

                new TourOrTwoToursParallel(new List<TourPlace>()
                {
                    new TourPlace(ZooZonesType.BirdZone),
                }),
                new TourOrTwoToursParallel(new List<TourPlace>()
                {
                    new TourPlace(ZooZonesType.AmphibiaZone),
                    new TourPlace(ZooZonesType.BirdZone)
                }),
                new TourOrTwoToursParallel(new List<TourPlace>()
                {
                    new TourPlace(ZooZonesType.AmphibiaZone),
                })
            };
            List<Employee> Employees = new List<Employee>()
                {
                    new Doctor("Assaf The Doc")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.BirdZone,
                    },
                    new Cleaner("Raz the employee")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.AmphibiaZone,
                    },
                    new Feeder("Amit the Tal")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.OrdinaryLandZone
                    },
                    new Feeder("Guy the coder")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.SeaCreatureZone
                    },
                    new Feeder("Eyal the nice")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.OrdinaryLandZone
                    },
                    new Doctor("Liav")
                    {
                        ApplicationConstantsInjection = ApplicationConstantsDependencyInjection,
                        CurrentWorkingZone = ZooZonesType.SeaCreatureZone
                    }
                };
            ZooTimingScheduler zooHandler = new
            (
                zones,
                Employees,
                Tours,
                Visitors



            );

            zooHandler.RunAllTours();
        }

        private Dictionary<ZooZonesType, List<Animal>> GetAnimalsZone()
        {
            List<Animal> animals = new()
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

            Dictionary<ZooZonesType, List<Animal>> regionAndItsAnimals = GetAnimalsInZone(animals);
            return regionAndItsAnimals;
        }
    }
}
