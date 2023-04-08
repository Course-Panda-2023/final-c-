namespace zoo.ManagerPackage;


public delegate void LogMessage(string message);


public class Manager
{
    private static Manager mInstance = null;
    private static readonly object mLocker = new Object();

    private Manager() { }

    public static Manager Instance
    {
        get
        {
            lock (mLocker)
            {
                if (mInstance == null)
                {
                    mInstance = new Manager();
                }

                return mInstance;
            }
        }
    }

    public static void ConsoleLog(string message)
    {
        Console.WriteLine(message);
    }

    public static void FileLog(string logMessage, string fileName)
    {
        using (StreamWriter file = new StreamWriter(@"/Users/ilanmotiei/Desktop/army/zoo/logs/" + fileName, true))
        {
            file.WriteLine(logMessage);
        }
    }
}