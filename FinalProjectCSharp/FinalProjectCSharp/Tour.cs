using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProjectCSharp
{
    public class Tour
    {
        private Area _areaTour;
        public Area AreaTour { get { return _areaTour; } }
        private List<Visitor> _visitors;
        public Tour(Area area) 
        {
            _areaTour = area;
            _visitors = new List<Visitor>();
        }

        public bool AddVisitor(Visitor visitor)
        {
            if (_visitors.Count < 5)
            {
                _visitors.Add(visitor);
                return true;
            }
            return false;
        }

        public void RemoveVisitors()
        {
            _visitors.RemoveRange(0, _visitors.Count);
        }

        public void startTour( List<Animal> animalsInArea)
        {
            Thread tourPlay = new Thread(() =>
            {
                Console.WriteLine($"Tour in {AreaTour} start");
                foreach (Animal animal in animalsInArea)
                    animal.MakeSound();
                Console.WriteLine($"Tour in {AreaTour} end");
            }); 
            tourPlay.Start();
            tourPlay.Join();
            RemoveVisitors();
        }
    }
}
