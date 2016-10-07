using System;
using System.ServiceModel;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class AuthManagerClientProxy : ClientBase<IAuthManager>, IAuthManager
    {
        public LoginData? Login(User user)
        {
            return Channel.Login(user);
        }

        public void Logout(Guid sessionGuid)
        {
            Channel.Logout(sessionGuid);
        }

        public int? GetLoggedInUserId(Guid sessionGuid)
        {
            return Channel.GetLoggedInUserId(sessionGuid);
        }
    }
}