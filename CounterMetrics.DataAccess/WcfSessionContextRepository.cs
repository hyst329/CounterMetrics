using System;
using System.Collections.Generic;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    public class WcfSessionContextRepository : ISessionContextRepository
    {
        private readonly WcfSessionContextHelper _sessionContextHelper;
        private readonly Dictionary<Guid, int> _sessions;

        public WcfSessionContextRepository(WcfSessionContextHelper sessionContextHelper)
        {
            _sessionContextHelper = sessionContextHelper;
            _sessions = new Dictionary<Guid, int>();
        }

        public Guid Add(int userId)
        {
            var guid = Guid.NewGuid();
            _sessions.Add(guid, userId);
            _sessionContextHelper.UserId = userId;
            _sessionContextHelper.SessionGuid = guid;
            return guid;
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