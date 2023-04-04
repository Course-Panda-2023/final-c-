using Zoo.EventLogger;
using Zoo.Util.Enum;

namespace Zoo.Model.Employee
{
    internal abstract class Employee
    {
        public ApplicationConstants? ApplicationConstantsInjection { get; init; }

        public string? Name { get; init; }

        public ZooZonesType CurrentWorkingZone { get; set; }

        protected int StartingTime { get; set; }

        public Employee()
        {
            Random random = new();
            StartingAtTime(random.Next(1, 4));
        }

        public void StartingAtTime(int time)
        {
            StartingTime = time;
            Thread thread = new(() =>
            {
                Thread.Sleep(time * 1000);
                string message = $"Employee {Name} starts at {time} working at {ApplicationConstantsInjection?.Places[CurrentWorkingZone]}";
                Console.WriteLine(message);
                EventLoggerSingleton.GetInstance().LogIntoEvent(message);
            });
            thread.Start();
        }
    }
}
