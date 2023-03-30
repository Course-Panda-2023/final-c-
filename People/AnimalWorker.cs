
abstract class AnimalWorker : Worker
{
    protected AnimalWorker(string name) : base(name){}

    public Animal? Animal {get; set;} = null;

    public bool IsAnimalTreatable(Animal animal) {return !animal.Treated;}

    public bool TreatAnimal(Animal animal) 
    {
        if (IsAnimalTreatable(animal))
        {
            Console.WriteLine($"Worker {this.Name} is now treating {animal.GetName()}");
            this.Animal = animal;
            animal.Treated = true;
            return true;
        }
        return false;
    }

    public void UntreatAnimal()
    {
        Console.WriteLine($"Worker {this.Name} stopped treating {this.Animal.GetName()}");
        this.Animal.Treated = false;
        this.Animal = null;
    }

    internal void FindAnimal(List<Animal> animals, Area area)
    {
        Random rand = new Random();
        foreach (Animal animal in animals.OrderBy(a => rand.Next()).ToList())
        {
            if(animal.GetArea() == area && this.TreatAnimal(animal))
                return;            
        }
        Console.WriteLine($"Worker {this.Name} couldn't find an animal to treat");

    }
}