using System;

namespace CounterMetrics.Infrastructure
{
    public class Logger : ILogger
    {
        public void Log(LogSeverity severity, string message)
        {
            Console.WriteLine("[Logger] {0,16}: {1}", severity, message);
        }
    }
}