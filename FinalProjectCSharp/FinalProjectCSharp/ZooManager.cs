using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class ZooManager
    {
        private static ZooManager _instance = null;
        private List<string> _events;
        private static readonly object lockObj = new object();
        private static readonly string DATA_TIME = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        private static string PATH =System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "");
        private readonly string logPath = @""+Path.Combine(PATH, $"EventLogs_{DATA_TIME}.txt");
        
        private ZooManager()
        {
            _events = new List<string>();
        }
        public static ZooManager GetInstance
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new ZooManager();
                    }
                    return _instance;
                }
            }
        }

        public void InitiateLog()
        {
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                foreach (string item in _events)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public void AddToLog(string ZooEvent)
        {
            _events.Add(ZooEvent);
       }

    }
}
