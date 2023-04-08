using zoo;
using zoo.AnimalPackage;
using zoo.AnimalPackage.Air;
using zoo.AnimalPackage.Ground;
using zoo.AnimalPackage.Mixed;
using zoo.AnimalPackage.Sea;
using zoo.Area;
using zoo.TimePackage;
using zoo.WorkerPackage;
using zoo.ManagerPackage;


LogMessage logger = Manager.ConsoleLog;
string logsFileName = $"EventLogs_{DateTime.Now.ToString("dd.MM.yyyy_HH:mm:ss")}.txt";
logger += logMessage => Manager.FileLog(logMessage, logsFileName);


List<Worker> workers = new List<Worker>
{
    new Doctor("Doctor1", logger),
    new Cleaner("Cleaner1", logger),
    new Feeder("Feeder1", logger)
};

List<Animal> animals = new List<Animal>
{
    new Eagle("eagle1", logger),
    new Hawk("hawk1", logger),
    new Owl("owl1", logger),
    new Pelican("pelican1", logger),
    new Vulture("vulture1", logger),

    new Elephant("elphant1", logger),
    new Giraffe("giraffe1", logger),
    new Kangaroo("kangaroo1", logger),
    new Lion("lion1", logger),
    new Zebra("zerba1", logger),

    new Alligator("alligator1", logger),
    new Duck("duck1", logger),
    new Frog("frog1", logger),
    new Hippopotamus("hippopotamus1", logger),
    new Turtle("turtle1", logger),

    new Dolphin("dolphin1", logger),
    new GoldFish("goldfish1", logger),
    new Pufferfish("pufferfish1", logger),
    new Shark("shark1", logger),
    new Whale("whale1", logger)
};


Zoo zoo = new Zoo(
    animals: animals,
    workers: workers,
    daytime:120,
    areas:new []
    {
        AreaType.AIR, AreaType.SEA, AreaType.MIXED, AreaType.GROUND
    },
    logger:logger
);

Time.Attach(zoo);

foreach (Worker worker in workers)
{
    Time.Attach(worker);
}

Time.Run(verboseTime: true);