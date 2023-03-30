
using System.Dynamic;

abstract class Worker : Person
{
    public Area? Area;
    protected int WorkTime;
    public int WorkerTicketFee;

    public Worker(string name) : base(name){}

    public void ChangeArea(Area? area)
    {
        this.Area = area;
    }
    public string GetName()
    {
        return this.Name;
    }
}