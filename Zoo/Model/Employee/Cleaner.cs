using Zoo.EventLogger;

namespace Zoo.Model.Employee
{
    internal class Cleaner : Employee
    {
        public event EventHandler<EmployeeEventArgs>? EndsWorksAt;

        public Cleaner(string CleanerName, int workTakesInSeconds = 2) : base()
        {
            WorkTakesInSeconds = workTakesInSeconds;
            EmployeeEventArgs args = new()
            {
                EmployeeName = CleanerName,
                WorkTakesInSeconds = workTakesInSeconds,
                DayStartingTime = StartingTimeOfDay
            };

            EndsWorksAt += EndingWorksAt;

            EndsWorksAt?.Invoke(this, args);
        }

        public static void EndingWorksAt(object? sender, EventArgs e)
        {
            Employee? employee = sender as Employee;
            EmployeeEventArgs? args = e as EmployeeEventArgs;

            Thread thread = new(() =>
            {
                Thread.Sleep(args.DayStartingTime);
                Thread.Sleep(args.WorkTakesInSeconds * 1000);
                string message = $"Doctor {args.EmployeeName} ends at {args.WorkTakesInSeconds + args.DayStartingTime}";

                Console.WriteLine(message);
                LogToFileSingleton.GetInstance().LogIntoEvent(message);
            });

            thread.Start();
        }
    }
}
