using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cleaner : Worker
{
    private event Manager.Announcement ToAnnounce;
    public Cleaner()
    {
        base.TotalWorkTime = 2;
        base.workedTime = TotalWorkTime + 1;
        CurZone = null;
        this.ToAnnounce += Manager.Instance.Announce;
        base.PriceChange = 30;
    }
    protected override void EndShift(int time)
    {
        this.ToAnnounce?.Invoke($"Stopped cleaning {base.CurZone} in time {time}");
        CurZone = null;
        base.workedTime = TotalWorkTime + 1;
    }
    protected override void StartShift(Zone zone, int time)
    {
        CurZone = zone;
        this.ToAnnounce?.Invoke($"Started cleaning {base.CurZone} in time {time}");

    }
}
