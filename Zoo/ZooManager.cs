using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Zoo
{
    //SINGLETON
    public class ZooManager
    {
        private static ZooManager mInstance = null;
        private static readonly object mLocker = new Object();
        string filePath;
        string fileName;

        private ZooManager() { }

        public static ZooManager Instance
        {
            get
            {
                lock (mLocker)
                {
                    if (mInstance == null)
                    {
                        mInstance = new ZooManager();
                        mInstance.filePath = @"C:\Users\User\Desktop\C#\final-c\Zoo\";
                        mInstance.fileName = $"{mInstance.filePath}Eventlogs_{DateTime.Now.ToString("dd.MM.yyyy_HH.mm")}.txt";
                    }
                    return mInstance;
                }
            }
        }

        public void LogEvents(string events)
        {
            lock (filePath)
            {
                Console.WriteLine(events);
                File.AppendAllText(mInstance.fileName, Environment.NewLine + events);
            }
        }
    }
}
