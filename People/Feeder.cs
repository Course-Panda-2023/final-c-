
class Feeder : AnimalWorker
{
    public Feeder(string name) : base (name)
    {
        this.WorkTime = 10;
        this.WorkerTicketFee = 100;
    }
}
