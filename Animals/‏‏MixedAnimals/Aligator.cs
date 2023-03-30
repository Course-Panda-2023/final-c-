
class Aligator : MixedAnimal
{
    public Aligator() 
    {
        this.Name = "Aligator";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"AligatorSound ({this.Name})");
    }
}
