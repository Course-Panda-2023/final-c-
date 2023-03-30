

public class Manager
{
    private static Manager? instance = null;
    string Path;
    private Manager() {}

    public static Manager CreateInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new Manager();
                instance.Path = $"EventLogs_{DateTime.Now.ToString("dd.MM.yyyy_HH-mm")}.txt";
            }

            return instance;
        }
    }

    public void AddReport(string report)
    {
        Console.WriteLine(report);
        File.AppendAllText(instance.Path, Environment.NewLine + report);
    }
    
}

