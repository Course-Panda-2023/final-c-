using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public static class TestingZoo
    {
        // Check the add function 
        public static void TestAddAnimal()
        {
            Zoo zoo = new Zoo();
            List<Animal> animals = HelperFunctions.GetAnimals();
            foreach(Animal animal in animals)
                Console.WriteLine($"Animal Name: {animal.AnimalName}, Area: {animal.GetArea}");

            Console.WriteLine("We expect to see only one animal for each type");

            foreach (Animal animal in animals)
                zoo.AddAnimal(animal);

            Console.ReadLine();
        }
        // Check the remove function
        public static void TestRemoveAnimal()
        {
            Zoo zoo = new Zoo();
            List<Animal> animals = HelperFunctions.GetAnimals();
            foreach (Animal animal in animals)
                zoo.AddAnimal(animal);
            Console.WriteLine();

            zoo.RemoveAnimal();

            Console.WriteLine("\nwe expect the animal removed from the list of animals");

            Console.WriteLine();
            zoo.ShowAnimals();

            Console.ReadLine();
        }

        public static void TestAddWorker()
        {
            Zoo zoo = new Zoo();
            List<ZooWorker> workers = HelperFunctions.GetZooWorkers();
            Console.WriteLine("Adding the first worker from the list");
            Console.WriteLine($"Name: {workers[0].Name}");
            zoo.AddWorker(workers[0]);
            Console.WriteLine($"Try to add it again, \n" +
                $"we expected to get False - {zoo.AddWorker(workers[0])}");

            Console.ReadLine();
        }
    }
}
