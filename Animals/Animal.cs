
interface IAnimal
{
    public void MakeSound();
}

abstract class Animal : IAnimal
{
    protected string? Name;
    protected Area Area;
    public bool Treated = false;

    public void MakeSound(){}

    public string GetName()
    {
        return this.Name == null ? "" : this.Name;
    }
    public Area GetArea()
    {
        return this.Area;
    }
}