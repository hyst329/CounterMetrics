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
        private readonly ISessionContextRepository _sessionContextRepository;
        private readonly IHasher _hasher;

        public AuthManager(IUserRepository userRepository, ISessionContextRepository sessionContextRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _sessionContextRepository = sessionContextRepository;
        }

        public ISessionContext Login(User user)
        {
            //throw new NotImplementedException();
            var passwordHash = _hasher.Hash(user.Password);
            try
            {
                int userId =
                    _userRepository.Find()
                        .First(userEntity => userEntity.Name == user.Name && userEntity.PasswordHash == passwordHash).Id;
                return _sessionContextRepository.Add(userId);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }

        public void Logout(Guid sessionGuid)
        {
            //throw new NotImplementedException();
            _sessionContextRepository.Remove(sessionGuid);

        }
    }
}