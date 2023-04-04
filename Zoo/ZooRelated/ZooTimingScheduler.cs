using Zoo.Model.Employee;
using Zoo.Tour;

namespace Zoo.ZooRelated
{
    internal class ZooTimingScheduler
    {
        public List<AnimalsZone> AnimalsZones = new();

        public List<Employee> ZooEployees;

        public List<TourOrTwoToursParallel> Tours = new();

        public List<Visitor> ZooVisitors = new();

        public ZooTimingScheduler(List<AnimalsZone> AnimalsZones, List<Employee> Employees, List<TourOrTwoToursParallel> Tours, List<Visitor> Visitors)
        {
            this.AnimalsZones = AnimalsZones;
            ZooEployees = Employees;
            this.Tours = Tours;
            ZooVisitors = Visitors;
        }

        public void RunAllTours()
        {
            List<Action> toursOrderOfOperation = OrderTimingTours();

            foreach (Action activateTour in toursOrderOfOperation)
            {
                activateTour.Invoke();
            }
        }

        private List<Action> OrderTimingTours()
        {
            List<Action> toursOrderOfOperation = new();
            foreach (TourOrTwoToursParallel Tour in Tours)
            {
                toursOrderOfOperation.Add(Tour.touring);
            }

            return toursOrderOfOperation;
        }
    }
}
