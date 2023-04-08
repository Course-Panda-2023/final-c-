namespace zoo.TimePackage;


public class Time
{
    private static int _time = 1;
    private static readonly object MLocker = new Object();
    private static readonly List<ITimeSubscriber> Subscribers = new List<ITimeSubscriber>();
    private static readonly int TimeUnitMilliSeconds = 1000;

    public static int Value
    {
        get
        {
            lock (MLocker)
            {
                return _time;
            }
        }
    }

    private static void Increment()
    {
        lock (MLocker)
        {
            _time++;
        }
    }

    public static void Attach(ITimeSubscriber s)
    {
        lock (MLocker)
        {
            Subscribers.Add(s);
        }
    }

    public static void Remove(ITimeSubscriber s)
    {
        lock (MLocker)
        {
            Subscribers.Remove(s);
        }
    }

    private static void Notify()
    {
        lock (MLocker)
        {
            foreach (ITimeSubscriber s in Subscribers)
            {
                s.OnTimeStamp(Value);
            }
        }
    }
    
    public static void Run(bool verboseTime = true)
    {
        while (true)
        {
            if (verboseTime)
            {
                Console.WriteLine($"-------- time: {Value} --------");
            }
            Notify();
            Increment();
            Thread.Sleep(TimeUnitMilliSeconds);
        }
    }
}