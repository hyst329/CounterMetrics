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
        Counter[] FindByUserID(int userID, CounterType? counterType);

        [OperationContract]
        Counter[] FindAll();
    }
}