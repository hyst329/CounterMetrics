using System;

namespace CounterMetrics.Infrastructure
{
    public class SessionContext : ISessionContext
    {
        public Guid? SessionGuid { get; set; }

        public int UserId { get; set; }
    }
}
