using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IAuthManager
    {
        [OperationContract]
        void Login(User user);

        [OperationContract]
        void Logout();
    }
}