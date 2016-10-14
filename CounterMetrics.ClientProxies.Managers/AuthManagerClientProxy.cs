using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;
using System.Transactions;

namespace CounterMetrics.ClientProxies.Managers
{
    public class AuthManagerClientProxy : ClientBase<IAuthManager>, IAuthManager
    {
        public LoginData Login(User user)
        {
            return Channel.Login(user);
        }

        public void Logout()
        {
            Channel.Logout();
        }
    }
}