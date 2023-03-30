
class Lion : LandAnimal
{
    public Lion() 
    {
        this.Name = "Lion";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"Rawr ({this.Name})");
    }
}
