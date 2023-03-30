
class Dolphin : SeaAnimal
{
    public Dolphin() 
    {
        this.Name = "Dolphin";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"DolphinSound ({this.Name})");
    }
}
