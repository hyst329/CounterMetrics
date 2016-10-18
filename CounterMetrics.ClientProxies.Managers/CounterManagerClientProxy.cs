using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

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

        public Counter[] FindOwned(CounterType? counterType)
        {
            return Channel.FindOwned(counterType);
        }

        public Counter[] FindAll()
        {
            return Channel.FindAll();
        }
    }
}