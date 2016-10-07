using System.ServiceModel;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class AccountManagerClientProxy : ClientBase<IAccountManager>, IAccountManager
    {
        public void Register(User user)
        {
            Channel.Register(user);
        }
    }
}