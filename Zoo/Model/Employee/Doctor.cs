using Zoo.EventLogger;

namespace Zoo.Model.Employee
{
    internal class Doctor : Employee
    {
        public event EventHandler<EmployeeEventArgs>? EndsWorksAt;

        public Doctor(string DoctorName) : base()
        {
            EmployeeEventArgs? args = new()
            {
                EmployeeName = DoctorName,
                WorkTakesInSeconds = 5,
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
                EventLoggerSingleton.GetInstance().LogIntoEvent(message);
            });

            thread.Start();
        }
    }
}
