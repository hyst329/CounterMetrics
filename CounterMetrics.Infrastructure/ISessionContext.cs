using System;

namespace CounterMetrics.Infrastructure
{
    public interface ISessionContext
    {
        Guid? SessionGuid { get; set; }
        int UserId { get; set; }
    }
}
