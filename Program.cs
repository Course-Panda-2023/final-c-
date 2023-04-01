// See https://aka.ms/new-console-template for more information

using CSharp_Zoo.Animals;
using CSharp_Zoo.Animals.AerialZone;
using CSharp_Zoo.Animals.AquaticZone;
using CSharp_Zoo.Animals.GroundZone;
using CSharp_Zoo.Animals.MixedZone;
using CSharp_Zoo.Zoo;
using CSharp_Zoo.ZooWorkers;


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
Zoo zoo = new Zoo(zooDirector);
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

const int numWorkers = 10; 
for (int i = 0; i < numWorkers; i++)
{
    zoo.AddWorker(new Doctor());
    zoo.AddWorker(new Feeder());
    zoo.AddWorker(new Cleaner());
}

