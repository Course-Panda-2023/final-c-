using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AnimalWorker : Worker
{
    public Animal? CurAnimal { get; set; }
    private event Manager.Announcement ToAnnounce;
    public AnimalWorker()
    {
        this.ToAnnounce += Manager.Instance.Announce;
    }

    protected override void EndShift(int time)
    {
        
        if (CurAnimal is not null) 
        {
            this.ToAnnounce?.Invoke($"Stopped {WorkingVerb} {this.CurAnimal} in {base.CurZone} in time {time}");
            this.CurAnimal.WorkedOn = false;
            this.CurAnimal = null;
        }
        else
            this.ToAnnounce?.Invoke($"Stopped {WorkingVerb} Null in {base.CurZone} in time {time}");
        this.CurZone = null;
    }
    protected override void StartShift(Zone zone, int time)
    {
        this.CurZone = zone;
        FindAnimal();
        if (CurAnimal is not null)
            this.ToAnnounce?.Invoke($"Started {WorkingVerb} {this.CurAnimal} in {base.CurZone} in time {time}");
        else
            this.ToAnnounce?.Invoke($"Started {WorkingVerb} Null in {base.CurZone} in time {time}");
         
    }
    protected abstract string WorkingVerb { get; }
    private void FindAnimal()
    {
        if(this.CurAnimal is not null)
            this.CurAnimal.WorkedOn = false;

        foreach (Animal animal in Zoo.animals)
        {
            if(animal.LivingZone == this.CurZone && !animal.WorkedOn)
            {
                animal.WorkedOn = true;
                this.CurAnimal = animal;
                break;
            }
        }
    }
}
