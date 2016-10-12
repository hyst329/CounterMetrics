using System;
using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface ISessionContextRepository
    {
        [OperationContract]
        int? GetUserId(Guid sessionGuid);

        [OperationContract]
        ISessionContext Add(int userId);

        [OperationContract]
        void Remove(Guid sessionGuid);
    }
}