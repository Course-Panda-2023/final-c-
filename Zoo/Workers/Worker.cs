using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Worker
    {
        const int workDay = 120;
        protected Areas currentArea;
        protected int workingInterval;
        protected List<int> workingTimes;
        protected List<int> pastAreas;

        public List<int> WorkingTimes { get { return workingTimes; } }
        public int WorkingInterval { get { return workingInterval; } }
        public Areas CurrentArea { get { return currentArea; } set { currentArea = value; } }

        public Worker(Areas area)
        {
            currentArea = area;
            workingTimes = new List<int>();
            pastAreas = new List<int>();
            SetWorkTimes();
        }

        public void SetWorkTimes()
        {
            Random rnd = new Random();
            const int numOfAreas = 4;
            int timeCounter = 0;
            while (timeCounter <= numOfAreas)
            {
                bool TimeIsCorrect = true;
                int time = rnd.Next(0, workDay - workingInterval);
                foreach (int workT in workingTimes)
                {
                    if (time >= workT && time <= (workT + workingInterval + 1) && time <= (workDay - workingInterval))
                    {
                        TimeIsCorrect = false;
                    }
                }
                if(TimeIsCorrect)
                {
                    workingTimes.Add(time);
                    timeCounter++;
                }
            }
        }
        public int GetNextArea()
        {
            Random rnd = new Random();
            const int numOfAreas = 4;
            int area = rnd.Next(0, numOfAreas);
            for(int i = 0; i < pastAreas.Count; i++)
            {
                if (pastAreas[i] == area)
                {
                    area = rnd.Next(0, numOfAreas);
                    i = 0;
                }
            }
            return area;
        }
    }
}
