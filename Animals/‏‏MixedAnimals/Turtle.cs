
class Turtle : MixedAnimal
{
    public Turtle() 
    {
        this.Name = "Turtle";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"TurtleSound ({this.Name})");
    }
}
