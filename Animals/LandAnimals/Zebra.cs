
class Zebra : LandAnimal
{
    public Zebra() 
    {
        this.Name = "Zebra";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"ZebraSound ({this.Name})");
    }
}
