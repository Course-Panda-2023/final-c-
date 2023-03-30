using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public delegate void ManagerWrite(string str);
    internal class Manager
    {

        private static Manager instance = null;
        private static readonly object mLocker = new Object();
        private static string fullPath;

        private Manager()
        {
            DateTime now = DateTime.Now;
            string file = $"Logger-{now.Date.Month}-{now.Date.Day}-{now.Hour}-{now.Minute}.txt";
            string folder = @"C:\Users\mamag2\Desktop\eyal\c#\Zoo\Zoo\";
            fullPath = folder + file;
            Console.WriteLine(fullPath);
            using (StreamWriter sw = File.CreateText(fullPath)) ;
        }
        public static Manager Instance
        {
            get
            {
                lock (mLocker)
                {
                    if (instance == null)
                    {
                        instance = new Manager();
                    }
                    return instance;
                }
            }
        }

        public void ReportStartAnimals(AnimalWorker animalWorker,int time)
        {
            WriteToFile($"[{time}]{animalWorker.Name} started working at {animalWorker.Zone} treating {animalWorker.Animal.GetType()}");
        }
        public void ReportStartCleaner(Cleaner cleaner, int time)
        {
            WriteToFile($"[{time}]{cleaner.Name} started working at {cleaner.Zone}");
        }

        public void ReportFinishAnimals(AnimalWorker animalWorker, int time)
        {
            WriteToFile($"[{time}]{animalWorker.Name} finished working at {animalWorker.Zone} treating {animalWorker.Animal.GetType()}");
        }
        public void ReportFinishCleaner(Cleaner cleaner, int time)
        {
            WriteToFile($"[{time}]{cleaner.Name} finished working at {cleaner.Zone}");
        }
        public void WriteToFile(string str)
        {
            Console.WriteLine(str);
            lock (fullPath)
            {
                using (StreamWriter writer = File.AppendText(fullPath))
                {
                    writer.WriteLine(str);
                }
                Console.WriteLine(str);
            }

        }

    }



}
