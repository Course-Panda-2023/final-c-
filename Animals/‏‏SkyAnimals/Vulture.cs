
class Vulture : SkyAnimal
{
    public Vulture() 
    {
        this.Name = "Vulture";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"VultureSound ({this.Name})");
    }
}
