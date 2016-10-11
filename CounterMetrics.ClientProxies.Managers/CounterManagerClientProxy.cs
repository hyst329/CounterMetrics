using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class CounterManagerClientProxy : ClientBase<ICounterManager>, ICounterManager
    {
        public void Add(Guid sessionGuid, Counter counter)
        {
            Channel.Add(sessionGuid, counter);
        }

        public void Remove(Guid sessionGuid, Counter counter)
        {
            Channel.Remove(sessionGuid, counter);
        }

        public Counter[] FindOwned(Guid sessionGuid, CounterType? counterType)
        {
            return Channel.FindOwned(sessionGuid, counterType);
        }

        public Counter[] FindAll(Guid sessionGuid)
        {
            return Channel.FindAll(sessionGuid);
        }
    }
}