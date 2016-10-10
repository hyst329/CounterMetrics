using System;
using System.Collections.Generic;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace CounterMetrics.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserRepository _userRepository;
        private Dictionary<Guid, int> _sessions;

        public AuthManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _sessions=new Dictionary<Guid, int>();
        }

        public LoginData? Login(User user)
        {
            //throw new NotImplementedException();
            var passwordHash = ServiceLocator.Hasher.Hash(user.Password);
            try
            {
                int userId =
                    _userRepository.Find()
                        .First(userEntity => userEntity.Name == user.Name && userEntity.PasswordHash == passwordHash).Id;
                var guid = Guid.NewGuid();
                _sessions[guid] = userId;
                return new LoginData { Guid = guid, UserId = userId };
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }

        public void Logout(Guid sessionGuid)
        {
            //throw new NotImplementedException();
            _sessions.Remove(sessionGuid);

        }

        public int? GetLoggedInUserId(Guid sessionGuid)
        {
            int result;
            if (_sessions.TryGetValue(sessionGuid, out result)) return result;
            return null;
        }
    }
}