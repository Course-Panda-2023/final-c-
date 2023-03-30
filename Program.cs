
class Program
{
    static public void Main(String[] args)
    {
        List<Animal> animals = new List<Animal>();
        List<Visitor> visitors = new List<Visitor>();
        List<Cleaner> cleaners = new List<Cleaner>();
        List<Doctor> doctors = new List<Doctor>();
        List<Feeder> feeders = new List<Feeder>();
        
        animals.Add(new Elephant());
        animals.Add(new Lion());
        animals.Add(new Zebra());
        animals.Add(new Aligator());
        animals.Add(new Hippo());
        animals.Add(new Turtle());
        animals.Add(new Dolphin());
        animals.Add(new Goldfish());
        animals.Add(new Shark());
        animals.Add(new Eagle());
        animals.Add(new Hawk());
        animals.Add(new Vulture());

        cleaners.Add(new Cleaner("Cleaner1"));
        doctors.Add(new Doctor("Doctor1"));
        feeders.Add(new Feeder("Feeder1"));

        Zoo? zoo = Zoo.CreateZoo(animals, visitors, cleaners, doctors, feeders);
        
        bool BonusMode = false;
        zoo.RunDay(BonusMode);
    }
}