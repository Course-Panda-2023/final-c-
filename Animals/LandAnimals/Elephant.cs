
class Elephant : LandAnimal
{
    public Elephant() 
    {
        this.Name = "Elephant";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"ElephantSound ({this.Name})");
    }
}
