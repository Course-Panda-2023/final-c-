using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Tour
    {
        private ZoneType _zoneType;
        private bool _inProcess;
        private bool _isFinished;
        private bool _inPause;
        private ManualResetEvent _helper;
        public static int _tourId = 0;
        private int _myID;   
        private List<Visitor> _visitors;    

        public ManualResetEvent helper { get { return _helper; } }

        public bool isFinished { get { return _isFinished; } }  
        public bool inProcess { get { return _inProcess; } }

        public bool inPause { get { return _inPause; } }

        public ZoneType zoneType { get { return _zoneType; } }

        public List<Visitor> visitors { get { return _visitors; } }


        public Tour(List<Visitor> visitors) 
        {
            _inPause = false; 
            _isFinished= false;
            Random random = new Random();
            _zoneType = ZooClass._zones[random.Next(ZooClass._zones.Count)];
            _helper = new ManualResetEvent(initialState: true);
            _tourId++;   
            _myID = _tourId;
            _visitors = visitors;


        } 
        
        public void ReleaseVisitors()
        {
            foreach(Visitor visitor in _visitors) 
                visitor.inATour = false;    
            
        }

        public void Start(int time)
        {

        //Thread t = new Thread(() =>
        //{
        //    while (true)
        //    {
        //        //Do the work here
        //        _helper.WaitOne(Timeout.Infinite);
        //    }
        //});
        Thread thread = new Thread(() => DoingATour(time));
        thread.Start(); 


        }

        public void DoingATour(int time)
        {
            _inProcess = true;
            Manager.Instance.WriteToFile($"[{time}] started a tour[{_myID}] in {_zoneType} with {_visitors.Count} visitors");
            for(int i = 0; i < ZooClass._tourTime; i++)
            {
                Thread.Sleep(ZooClass._sec);
                time++;
                _helper.WaitOne(Timeout.Infinite);
            }
            Manager.Instance.WriteToFile($"[{time}] tour[{_myID}] in {_zoneType} is finished");
            ReleaseVisitors();
            _inProcess =false;
            _isFinished = true;  
        }

        public void StopTour()
        {
            _helper.Reset();
            _inPause = true;
            if(_inProcess) 
                Manager.Instance.WriteToFile($"tour[{_myID}] in {zoneType} is paused");
        }

        public void ResumeTour()
        {
            _helper.Set();
            _inPause = false;
            if (_inProcess)
                Manager.Instance.WriteToFile($"tour[{_myID}] in {zoneType} is unpaused");


        }
        //public void WaitForSignal()
        //{
        //    while (true)
        //    {
        //        _helper.WaitOne();
        //    }
        //}
    }
}
