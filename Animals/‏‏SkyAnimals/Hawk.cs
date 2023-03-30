
class Hawk : SkyAnimal
{
    public Hawk() 
    {
        this.Name = "Hawk";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"HawkSound ({this.Name})");
    }
}
