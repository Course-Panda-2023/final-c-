using Zoo.EventLogger;
using Zoo.Util.Enum;

namespace Zoo.Model.Employee
{
    internal abstract class Employee
    {
        public ApplicationConstants? ApplicationConstantsInjection { get; init; }

        public string? Name { get; init; }

        public ZonesType CurrentWorkingZone { get; set; }

        protected int StartingTimeOfDay { get; set; }

        protected int? WorkTakesInSeconds { get; set; }

        public Thread? ActiveTask;

        public Employee()
        {
            Random random = new();
            StartingTimeOfDay = random.Next(1, 4) * 1000; // seconds
            StartingAtTime();
        }

        public void StartingAtTime()
        {
            Thread ActiveTask = new(() =>
            {
                Thread.Sleep(StartingTimeOfDay);
                StreamsLogMessage();
            });
            ActiveTask.Start();
        }

        private void StreamsLogMessage()
        {
            string message = $"Employee {Name} starts at {StartingTimeOfDay} working at {ApplicationConstantsInjection?.Places[CurrentWorkingZone]}";
            Console.WriteLine(message);
            LogToFileSingleton.GetInstance().LogIntoEvent(message);
        }

        public bool IsDelayingTour(ZonesType zoneType)
        {
            return ActiveTask!.IsAlive && zoneType == CurrentWorkingZone;
        }
    }
}
