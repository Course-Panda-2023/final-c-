using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Manager
{
    private static Manager mInstance = null;
    private static readonly object mLocker = new Object();
    private static string fullPath;
    private Manager() 
    {
        DateTime now = DateTime.Now;
        string file = $"EventLog_{now.Day}.{now.Month}.{now.Year}_{now.Hour};{now.Minute}.txt";
        string folder = @"C:\Users\dan-client\Source\Repos\TamasZoo\output\";
        fullPath = folder + file;
        Console.WriteLine(fullPath);
        using (StreamWriter sw = File.CreateText(fullPath));
    }

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

    public delegate void Announcement(string str);
    public void Announce(string str)
    {
        lock (fullPath)
        {
            using (StreamWriter writer = File.AppendText(fullPath))
            {
                writer.WriteLine(str);
            }
        }
    }
}
