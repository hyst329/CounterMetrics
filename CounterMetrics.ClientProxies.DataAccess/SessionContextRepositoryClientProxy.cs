using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class SessionContextRepositoryClientProxy : ClientBase<ISessionContextRepository>, ISessionContextRepository
    {
        public SessionContextRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public int? GetUserId(Guid sessionGuid)
        {
            return Channel.GetUserId(sessionGuid);
        }

        public Guid Add(int userId)
        {
            return Channel.Add(userId);
        }

        public void Remove(Guid sessionGuid)
        {
            Channel.Remove(sessionGuid);
        }
    }
}