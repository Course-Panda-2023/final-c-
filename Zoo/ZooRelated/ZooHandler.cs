using System.Runtime.InteropServices;
using Zoo.Utils.CustomException;
using Zoo.Model.Animals;
using Zoo.Utils.EnumTypes;
using Zoo.ZooRelated.Tour;
using Zoo.Model.Employee;
using Zoo.Utils.OrdinaryUtils;

namespace Zoo.ZooRelated
{
    internal class ZooHandler
    {

        public List<ZooZone> zones = new();

        public List<Employee> employees;

        public List<EventHandler> employeesStarts = new();

        public List<EventHandler> employyeesEnds = new();

        public List<GuidedTour> guidedTours = new();

        public List<Visitor> visitors = new();

        public ZooHandler(List<ZooZone> zones, List<Employee> employees, List<GuidedTour> guidedTours, List<Visitor> Visitors)
        {
            this.zones = zones;
            this.employees = employees;
            this.guidedTours = guidedTours;
            this.visitors = Visitors;
        }

        public void RunAllTours()
        {
            List<Thread> threads = new List<Thread>();
            foreach (GuidedTour GuidedTour in guidedTours) 
            {
                threads.Add(GuidedTour.touring);
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }
        }
    }
}
