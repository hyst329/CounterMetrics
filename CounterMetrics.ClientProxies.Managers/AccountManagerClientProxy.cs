using System.ServiceModel;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class AccountManagerClientProxy : ClientBase<IAccountManager>, IAccountManager
    {
        public bool Register(User user)
        {
            return Channel.Register(user);
        }
    }
}