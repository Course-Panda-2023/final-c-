using Zoo.EventLogger;

namespace Zoo.Model.Employee
{
    internal class Doctor : Employee
    {
        public event EventHandler<EmployeeEventArgs>? EndsWorksAt;

        public Doctor(string DoctorName, int workTakesInSeconds = 5) : base()
        {
            WorkTakesInSeconds = workTakesInSeconds;
            EmployeeEventArgs? args = new()
            {
                EmployeeName = DoctorName,
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
