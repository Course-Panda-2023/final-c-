namespace Zoo.EventLogger
{
    internal static class EventLoggerSingleton
    {
        public static LogToFile? eventLogger = null;


        public static LogToFile GetInstance()
        {
            eventLogger ??= new LogToFile();

            return eventLogger;
        }
    }
}
