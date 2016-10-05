using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.Infrastructure
{
    public interface ILogger
    {
        void Log(LogSeverity severity, string message);
    }
    public enum LogSeverity { Info, Warning, Error}
}
