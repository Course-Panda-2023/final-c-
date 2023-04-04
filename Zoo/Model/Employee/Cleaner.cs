using Zoo.EventLogger;

namespace Zoo.Model.Employee
{
    internal class Cleaner : Employee
    {
        public event EventHandler<EmployeeEventArgs>? EndsWorksAt;

        public Cleaner(string CleanerName) : base()
        {
            EmployeeEventArgs args = new()
            {
                EmployeeName = CleanerName,
                StartTime = 2,
                DayStartingTime = StartingTime
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
                Thread.Sleep(args.StartTime * 1000);
                string message = $"Doctor {args.EmployeeName} ends at {args.StartTime + args.DayStartingTime}";

                Console.WriteLine(message);
                EventLoggerSingleton.GetInstance().LogIntoEvent(message);
            });

            thread.Start();
        }
    }
}
