using System;
using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    [ServiceKnownType(typeof(WcfSessionContextHelper))]
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