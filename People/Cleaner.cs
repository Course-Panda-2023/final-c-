
class Cleaner : Worker
{
    public Cleaner(string name) : base (name)
    {
        this.WorkTime = 2;
        this.WorkerTicketFee = 30;
    }
}