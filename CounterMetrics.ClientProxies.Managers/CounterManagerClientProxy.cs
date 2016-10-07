using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class CounterManagerClientProxy : ClientBase<ICounterManager>, ICounterManager
    {
        public void Add(Counter counter)
        {
            Channel.Add(counter);
        }

        public void Remove(Counter counter)
        {
            Channel.Remove(counter);
        }

        public Counter[] FindByUserId(int userId, CounterType? counterType)
        {
            return Channel.FindByUserId(userId, counterType);
        }

        public Counter[] FindAll()
        {
            return Channel.FindAll();
        }
    }
}