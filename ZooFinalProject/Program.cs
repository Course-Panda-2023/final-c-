namespace ZooFinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            // create different animal objects
            Animal lion = new GroundAnimal("Lion", "ROARRRRR", Location.Ground);
            Animal elephant = new GroundAnimal("Elephant", "FWOOOOOOOOO", Location.Ground);
            Animal zebra = new GroundAnimal("Zebra", "*zebra sounds*", Location.Ground); //thanks mom and dad
            Animal giraffe = new GroundAnimal("Giraffe", "*tall sounds*", Location.Ground);
            Animal kangaroo = new GroundAnimal("Kangaroo", "hopping", Location.Ground);

            Animal dolphin = new SeaAnimal("Dolphin", "clicks", Location.Sea);
            Animal goldfish = new SeaAnimal("Goldfish", "gold noises", Location.Sea);
            Animal shark = new SeaAnimal("Shark", "GRRRRRRRRRR WHERE IS NEMO", Location.Sea);
            Animal whale = new SeaAnimal("Whale", "*big whale sounds*", Location.Sea);
            Animal abunafha = new SeaAnimal("Abu Nafha", "blowing", Location.Sea);

            Animal eagle = new AirAnimal("Eagle", "SQUAAAWKKKKK", Location.Air);
            Animal hawk = new AirAnimal("Hawk", "SQUUAAAWKKK", Location.Air);
            Animal vulture = new AirAnimal("Vulture", "Squawk", Location.Air);
            Animal owl = new AirAnimal("Owl", "Squawk", Location.Air);
            Animal pelican = new AirAnimal("Pelican", "Squawk", Location.Air);

            Animal crocodile = new MixedAnimal("Crocodile", "GRRRRRR", Location.Mixed);
            Animal hippo = new MixedAnimal("Hippo", "GRRRRR", Location.Mixed);
            Animal turtle = new MixedAnimal("Turtle", "*silent sounds*", Location.Mixed);
            Animal frog = new MixedAnimal("Frog", "CROAK", Location.Mixed);
            Animal duck = new MixedAnimal("Duck", "Quack", Location.Mixed);

            zoo.AddAnimal(lion);
            zoo.AddAnimal(elephant);
            zoo.AddAnimal(zebra);
            zoo.AddAnimal(giraffe);
            zoo.AddAnimal(kangaroo);

            zoo.AddAnimal(dolphin);
            zoo.AddAnimal(goldfish);
            zoo.AddAnimal(shark);
            zoo.AddAnimal(whale);
            zoo.AddAnimal(abunafha);

            zoo.AddAnimal(eagle);
            zoo.AddAnimal(hawk);
            zoo.AddAnimal(vulture);
            zoo.AddAnimal(owl);
            zoo.AddAnimal(pelican);

            zoo.AddAnimal(crocodile);
            zoo.AddAnimal(hippo);
            zoo.AddAnimal(turtle);
            zoo.AddAnimal(frog);
            zoo.AddAnimal(duck);

            zoo.CheckAnimalDistribution();

            // create different worker objects
            Feeder feeder1 = new Feeder("John", Location.Ground, lion);
            Feeder feeder2 = new Feeder("Sarah", Location.Sea, elephant);
            Feeder feeder3 = new Feeder("Tom", Location.Air, zebra);
            Feeder feeder4 = new Feeder("Kate", Location.Mixed, shark);
            Doctor doctor1 = new Doctor("Mike", Location.Ground, lion);
            Doctor doctor2 = new Doctor("Kelly", Location.Sea, dolphin);
            Doctor doctor3 = new Doctor("Alex", Location.Air, eagle);
            Doctor doctor4 = new Doctor("David", Location.Mixed, shark);
            Janitor janitor1 = new Janitor("Jake", Location.Ground, lion);
            Janitor janitor2 = new Janitor("Maggie", Location.Sea, dolphin);
            Janitor janitor3 = new Janitor("Bob", Location.Mixed, shark);
            Janitor janitor4 = new Janitor("Alice", Location.Air, zebra);

            // add the workers and animals to the zoo
            zoo.AddAnimal(lion);
            zoo.AddAnimal(elephant);
            zoo.AddAnimal(zebra);
            zoo.AddAnimal(dolphin);
            zoo.AddAnimal(shark);
            zoo.AddAnimal(eagle);
            //zoo.AddAnimal(eagle1);
            //zoo.AddAnimal(eagle2);
            //zoo.AddAnimal(eagle3);
            //zoo.AddAnimal(shark1);
            //zoo.AddAnimal(shark2);
            //zoo.AddAnimal(shark3);
            zoo.AddWorker(feeder1);
            zoo.AddWorker(feeder2);
            zoo.AddWorker(feeder3);
            zoo.AddWorker(feeder4);
            zoo.AddWorker(doctor1);
            zoo.AddWorker(doctor2);
            zoo.AddWorker(doctor3);
            zoo.AddWorker(doctor4);
            zoo.AddWorker(janitor1);
            zoo.AddWorker(janitor2);
            zoo.AddWorker(janitor3);
            zoo.AddWorker(janitor4);

            zoo.SimulateTourDay();

            zoo.CreateLogs();

            Console.ReadKey();

        }
    }
}