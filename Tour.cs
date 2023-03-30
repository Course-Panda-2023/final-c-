
using System.Diagnostics;

class Tour
{
    const int NUM_SECONDS = 10;
    public static int tourNum = 1; 
    private int tourID;
    public Area Area;
    static Manager Manager = Manager.CreateInstance;
    public List<Visitor> Visitors;
    public Thread thread; 
    private ManualResetEvent ManualResetEvent = new ManualResetEvent(true);
    public bool IsOngoing;
    public bool IsFinished;

    public Tour(List<Visitor> visitors, Area area, Manager manager)
    {
        this.tourID = tourNum;
        this.Visitors = visitors;
        this.Area = area;
        thread = new Thread(() => RunTour());
    }

    public void RunTour()
    {
        Manager.AddReport($"Tour {this.tourID} in area {this.Area} is starting.");
        tourNum++;
        this.IsOngoing = true;
        this.IsFinished = false;
        for(int i=0; i<NUM_SECONDS; i++)
        {
            Thread.Sleep(100);
            this.ManualResetEvent.WaitOne(Timeout.Infinite);
        }
        Manager.AddReport($"Tour {this.tourID} in area {this.Area} is finished.");
        
        this.IsOngoing = false;
        this.IsFinished = true;
    }

    public void StopTour()
    {
        Manager.AddReport($"Tour {this.tourID} is stopping");
        this.IsOngoing = false;
        this.ManualResetEvent.Reset();
    }
    public void ResumeTour()
    {
        Manager.AddReport($"Tour {this.tourID} is resuming");
        this.IsOngoing = true;
        this.ManualResetEvent.Set();
    }
}