using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Utils.OrdinaryUtils
{
    internal static class EventLoggerSingleton
    {
        public static EventLogger? eventLogger = null;


        public static EventLogger GetInstance()
        {
            if (eventLogger == null)
            {
                eventLogger = new EventLogger();
            }

            return eventLogger;
        }
    }
}
