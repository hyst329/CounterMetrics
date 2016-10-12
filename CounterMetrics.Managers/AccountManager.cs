using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IHasher _hasher;
        private readonly IUserRepository _userRepository;

        public AccountManager(IUserRepository userRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public bool Register(User user)
        {
            //throw new NotImplementedException();
            var newUserId = _userRepository.GetFreeId();
            var passwordHash = _hasher.Hash(user.Password);
            if (_userRepository.Find().Count(userEntity => userEntity.Name == user.Name) != 0)
                return false;
            _userRepository.Create(new UserEntity {Id = newUserId, Name = user.Name, PasswordHash = passwordHash});
            return true;
        }
    }
}