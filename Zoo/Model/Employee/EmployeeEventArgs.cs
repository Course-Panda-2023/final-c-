namespace Zoo.Model.Employee
{
    public class EmployeeEventArgs : EventArgs
    {
        public string? EmployeeName { get; set; }

        public int WorkTakesInSeconds { get; set; }

        public int DayStartingTime { get; set; }
    }

}