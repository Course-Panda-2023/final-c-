
using System.Reflection.Metadata;

class Doctor : AnimalWorker
{   
    public Doctor(string name) : base (name)
    {
        this.WorkTime = 5;
        this.WorkerTicketFee = 20;
    }
}