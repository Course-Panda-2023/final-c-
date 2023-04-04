namespace Zoo.EventLogger
{
    internal static class EventLoggerSingleton
    {
        public static EventLogger? eventLogger = null;


        public static EventLogger GetInstance()
        {
            eventLogger ??= new EventLogger();

            return eventLogger;
        }
    }
}
