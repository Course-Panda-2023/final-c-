
class Goldfish : SeaAnimal
{
    public Goldfish() 
    {
        this.Name = "Goldfish";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"GoldfishSound ({this.Name})");
    }
}
