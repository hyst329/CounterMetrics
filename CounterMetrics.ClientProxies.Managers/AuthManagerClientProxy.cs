using System.ServiceModel;
using CounterMetrics.Contracts.Managers;

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