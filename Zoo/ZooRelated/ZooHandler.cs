using Zoo.Model.Employee;
using Zoo.Tour;

namespace Zoo.ZooRelated
{
    internal class ZooHandler
    {

        public List<ZooZone> zones = new();

        public List<Employee> employees;

        public List<EventHandler> employeesStarts = new();

        public List<EventHandler> employyeesEnds = new();

        public List<TourOrTwoTours> guidedTours = new();

        public List<Visitor> visitors = new();

        public Queue<TourOrTwoTours> guidedToursQueue = new();

        public ZooHandler(List<ZooZone> zones, List<Employee> employees, List<TourOrTwoTours> guidedTours, List<Visitor> Visitors)
        {
            this.zones = zones;
            this.employees = employees;
            this.guidedTours = guidedTours;
            foreach (var guidedTour in guidedTours)
            {
                guidedToursQueue.Enqueue(guidedTour);
            }
            this.visitors = Visitors;
        }

        public void RunAllTours()
        {
            List<Thread> threads = new List<Thread>();
            foreach (TourOrTwoTours GuidedTour in guidedTours)
            {
                threads.Add(GuidedTour.touring);
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }
        }
    }
}
