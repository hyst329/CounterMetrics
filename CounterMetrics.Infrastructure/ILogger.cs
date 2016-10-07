namespace CounterMetrics.Infrastructure
{
    public interface ILogger
    {
        void Log(LogSeverity severity, string message);
    }

    public enum LogSeverity
    {
        Info,
        Warning,
        Error
    }
}