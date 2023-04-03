﻿using System.Runtime.CompilerServices;
using Zoo.EventLogger;
using Zoo.Model.Animals;
using Zoo.Utils.Enum;

namespace Zoo.Model.Employee
{
    internal class Feeder : Employee
    {
        public event EventHandler<EmployeeEventArgs> EndsWorksAt;

        public Feeder(string DoctorName)
        {
            EmployeeEventArgs args = new EmployeeEventArgs();
            args.EmployeeName = DoctorName;
            args.StartTime = 5;
            args.DayStartingTime = this.StartingTime;
            EndsWorksAt += EndingWorksAt;

            // Raise the event
            EndsWorksAt?.Invoke(this, args);
        }

        public static void EndingWorksAt(object sender, EventArgs e)
        {
            Employee employee = sender as Employee;
            EmployeeEventArgs args = e as EmployeeEventArgs;

            Thread thread = new Thread(() =>
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
