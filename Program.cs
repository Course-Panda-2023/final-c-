// See https://aka.ms/new-console-template for more information

using CSharp_Zoo;
using CSharp_Zoo.Animals;
using CSharp_Zoo.Animals.AerialZone;
using CSharp_Zoo.Animals.AquaticZone;
using CSharp_Zoo.Animals.GroundZone;
using CSharp_Zoo.Animals.MixedZone;
using CSharp_Zoo.Zoo;
using CSharp_Zoo.ZooWorkers;
using System;
using Microsoft.Win32.SafeHandles;


//Running test code
/*Console.WriteLine("Hello, World!");
Animal eagle = new Eagle("Fasty");
Animal lion = new Lion("Liony");
Console.WriteLine(eagle.Name, lion.Name);
Console.WriteLine(eagle.GetZone());
Console.WriteLine(lion.GetZone());
lion.MakeSound();*/


//Running test code
Director zooDirector = Director.Instance;
Zoo zoo = new Zoo();
zoo.AddAnimal(new Eagle("Fasty"));
zoo.AddAnimal(new Parrot("Parroty"));
zoo.AddAnimal(new Lion("Liony"));
zoo.AddAnimal(new Elephant("Elephanty"));
zoo.AddAnimal(new Pigeon("Pigeony"));
zoo.AddAnimal(new Dolphin("Deplhi"));
zoo.AddAnimal(new Seal("Seally"));
zoo.AddAnimal(new Whale("Whally"));
zoo.AddAnimal(new Rat("Ratty"));
zoo.AddAnimal(new PolarBear("Bearry"));
zoo.AddAnimal(new Crocodile("Crocody"));
zoo.AddAnimal(new Hippopotamus("Hippy"));

const int numWorkers = 2; 
for (int i = 0; i < numWorkers; i++)
{
    //zoo.AddWorker(new Doctor());
    //zoo.AddWorker(new Feeder());
    zoo.AddWorker(new Cleaner());
}

if (zoo.Workers == null || zoo.Animals == null)
{
    Console.WriteLine("Zoo object is not initialized");
}
//Console.WriteLine(zoo.Workers.Count);
Tours tours = new Tours(zoo);
/*Task.Run(async () =>
{
    var random = new Random();
    while (true)
    {
        var visitor = new Visitors { Name = $"Visitor{random.Next(1000, 9999)}" };
        tours._waitingVisitors.Add(visitor);
        await Task.Delay(TimeSpan.FromSeconds(random.Next(1, 5)));
    }
});*/

// Subscribe to TourStarted and TourFinished events
//var random = new Random();
//var visitor = new Visitors(random.Next(10, 30));

/*tours.TourStarted += (sender, e) =>
{
    Console.WriteLine($"Tour started at {e.Tour.StartTime} in zone {e.Tour.Zone} with {e.Tour.Visitors.Count} visitors");
};

tours.TourFinished += (sender, e) =>
{
    Console.WriteLine($"Tour finished at {e.Tour.EndTime} in zone {e.Tour.Zone}");
};*/

// Run the tours
tours.Run();