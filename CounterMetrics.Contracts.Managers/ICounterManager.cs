using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface ICounterManager
    {
        [OperationContract]
        void Add(Guid sessionGuid, Counter counter);

        [OperationContract]
        void Remove(Guid sessionGuid, Counter counter);

        [OperationContract]
        Counter[] FindOwned(Guid sessionGuid, CounterType? counterType);

        [OperationContract]
        Counter[] FindAll(Guid sessionGuid);
    }
}