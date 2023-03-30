
class Shark : SeaAnimal
{
    public Shark() 
    {
        this.Name = "Shark";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"SharkSound ({this.Name})");
    }
}
