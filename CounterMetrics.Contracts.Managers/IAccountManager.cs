using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IAccountManager
    {
        [OperationContract]
        void Register(User user);
    }
}