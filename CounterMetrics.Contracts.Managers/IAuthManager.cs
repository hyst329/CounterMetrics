using CounterMetrics.Infrastructure;
using System;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{

    [ServiceContract]
    public interface IAuthManager
    {
        [OperationContract]
        ISessionContext Login(User user);

        [OperationContract]
        void Logout(Guid sessionGuid);
    }
}