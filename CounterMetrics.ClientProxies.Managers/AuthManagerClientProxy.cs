using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.ClientProxies.Managers
{
    public class AuthManagerClientProxy : ClientBase<IAuthManager>, IAuthManager
    {
        public ISessionContext Login(User user)
        {
            return Channel.Login(user);
        }

        public void Logout()
        {
            Channel.Logout();
        }
    }
}