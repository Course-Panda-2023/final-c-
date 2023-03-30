// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<Animal> animals = new List<Animal>();
animals.Add(new Owl("1"));
animals.Add(new Eagle("2"));
animals.Add(new Hawk("3"));
animals.Add(new Lion("4"));
animals.Add(new Zebra("5"));
animals.Add(new Giraffe("6"));
animals.Add(new Duck("7"));
animals.Add(new Frog("8"));
animals.Add(new Hippo("9"));
animals.Add(new Dolphin("10"));
animals.Add(new Shark("11"));
animals.Add(new Whale("12"));
List<Cleaner> cleaners = new List<Cleaner>();
cleaners.Add(new Cleaner());
List<Doctor> doctors= new List<Doctor>();
doctors.Add(new Doctor());
List<Feeder> feeders= new List<Feeder>();
feeders.Add(new Feeder());
Zoo zoo = new Zoo(animals, cleaners, doctors, feeders, 200);
zoo.StartDay();


