using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IAccountManager
    {
        [OperationContract]
        bool Register(User user);
    }
}