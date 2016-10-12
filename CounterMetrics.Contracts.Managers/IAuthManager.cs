using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IAuthManager
    {
        [OperationContract]
        ISessionContext Login(User user);

        [OperationContract]
        void Logout();
    }
}