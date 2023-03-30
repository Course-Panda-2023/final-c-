
class Eagle : SkyAnimal
{
    public Eagle() 
    {
        this.Name = "Eagle";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"EagleSound ({this.Name})");
    }
}
