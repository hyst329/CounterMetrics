using System;
using System.Collections.Generic;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class NoWcfSessionContextRepository : ISessionContextRepository
    {
        private readonly Dictionary<Guid, int> _sessions;

        public NoWcfSessionContextRepository()
        {
            _sessions = new Dictionary<Guid, int>();
        }

        public ISessionContext Add(int userId)
        {
            var guid = Guid.NewGuid();
            _sessions.Add(guid, userId);
            return new NoWcfSessionContextHelper {SessionGuid = guid, UserId = userId};
        }

        public int? GetUserId(Guid sessionGuid)
        {
            int result;
            if (_sessions.TryGetValue(sessionGuid, out result)) return result;
            return null;
        }

        public void Remove(Guid sessionGuid)
        {
            _sessions.Remove(sessionGuid);
        }
    }
}