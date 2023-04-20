using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class ZooManagerSingleton
    {
        private static ZooManagerSingleton mInstance = null;
        private string Path;
        private string MsgTemplate;

        private ZooManagerSingleton() { }

        public static ZooManagerSingleton Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new ZooManagerSingleton();
                    Instance.Path = "./MyLogs.txt";
                    Instance.MsgTemplate = $"EventLogs_{DateTime.Now.ToString("dd.MM.yyyy_HH-mm")} ";
                }

                return mInstance;
            }
        }

        public void AddDocumantation(string report)
        {
            Console.WriteLine(report);
            try
            {
                File.AppendAllText(Instance.Path, Environment.NewLine + Instance.MsgTemplate + report);
            }
            catch (Exception e) { Console.WriteLine("Logger is busy"); }
        }
    }
}
