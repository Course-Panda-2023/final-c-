namespace ZooFinalProject
{
    public class Manager
    {
        public List<string> events { get; set; }
        private static readonly string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        private readonly string logpath = @"C:\Users\guyal.DESKTOP-S2VGE0F\Source\Repos\ZooFinalProject\ZooFinalProject\EventLogs" + date + ".txt";
        public Manager()
        {
            events = new List<string>();
        }

        public void WriteZooLogs()
        {
            using (StreamWriter writer = new StreamWriter(logpath))
            {
                foreach (string item in events)
                {
                    writer.WriteLine(item);
                }
            }
            Console.WriteLine("log files created!");
        }

        public void AddToLogs(string ZooEvent)
        {
            events.Add(ZooEvent);
        }
    }

}
