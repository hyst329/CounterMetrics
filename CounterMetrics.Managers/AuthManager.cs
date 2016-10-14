using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly IHasher _hasher;
        private readonly ISessionContextHelper _sessionContextHelper;
        private readonly ISessionContextRepository _sessionContextRepository;
        private readonly IUserRepository _userRepository;

        public AuthManager(IUserRepository userRepository, ISessionContextRepository sessionContextRepository,
            ISessionContextHelper sessionContextHelper, IHasher hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _sessionContextRepository = sessionContextRepository;
            _sessionContextHelper = sessionContextHelper;
        }

        public LoginData Login(User user)
        {
            //throw new NotImplementedException();
            var passwordHash = _hasher.Hash(user.Password);
            try
            {
                var userId =
                    _userRepository.Find()
                        .First(userEntity => (userEntity.Name == user.Name) && (userEntity.PasswordHash == passwordHash))
                        .Id;
                Guid sessionGuid = _sessionContextRepository.Add(userId);
                _sessionContextHelper.Instance.SessionGuid = sessionGuid;
                _sessionContextHelper.Instance.UserId = userId;
                return new LoginData { SessionGuid = sessionGuid, UserId = userId };
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public void Logout()
        {
            //throw new NotImplementedException();
            _sessionContextRepository.Remove(_sessionContextHelper.Instance.SessionGuid);
        }
    }
}