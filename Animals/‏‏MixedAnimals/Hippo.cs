
class Hippo : MixedAnimal
{
    public Hippo() 
    {
        this.Name = "Hippo";
    }

    public new void MakeSound()
    {
        Console.WriteLine($"HippoSound ({this.Name})");
    }
}
