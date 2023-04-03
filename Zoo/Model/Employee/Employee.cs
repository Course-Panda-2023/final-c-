using Zoo.EventLogger;
using Zoo.Model.Animals;
using Zoo.Utils.Enum;

namespace Zoo.Model.Employee
{
    internal abstract class Employee
    {
        Dictionary<ZooZonesType, string> places = new()
        {
            { ZooZonesType.None, "" },
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };

        public string? Name { get; init; }

        public ZooZonesType CurrentWorkingZone { get; set; }

        public Animal? CurrentAnimal { get; set; }

        public EmployeesType Type { get; protected set; }

        public uint WorkingTimeSeconds { get; protected set; }

        public List<Thread> duties = new();

        protected int StartingTime { get; set; }

        public Employee()
        {
            Random random = new Random();
            StartingAtTime(random.Next(1, 4));
        }

        public void StartingAtTime(int time)
        {
            this.StartingTime = time;
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(time * 1000);
                string message = $"Employee {Name} starts at {time} working at {places[CurrentWorkingZone]}";
                Console.WriteLine(message);
                EventLoggerSingleton.GetInstance().LogIntoEvent(message);
            });
            thread.Start();
        }
    }
}
