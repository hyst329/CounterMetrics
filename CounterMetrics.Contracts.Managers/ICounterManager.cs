using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface ICounterManager
    {
        [OperationContract]
        void Add(Counter counter);

        [OperationContract]
        void Remove(Counter counter);

        [OperationContract]
        Counter[] FindOwned(CounterType? counterType);

        [OperationContract]
        Counter[] FindAll();
    }
}