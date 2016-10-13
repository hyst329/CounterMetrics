using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    [ServiceKnownType(typeof(WcfSessionContextHelper))]
    public interface IAuthManager
    {
        [OperationContract]
        ISessionContext Login(User user);

        [OperationContract]
        void Logout();
    }
}