using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
