using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly UserRepository userRepository;

        public AccountManager(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(User user)
        {
            //throw new NotImplementedException();
            var newUserID = userRepository.GetFreeID();
            var passwordHash = ServiceLocator.Hasher.Hash(user.Password);
            userRepository.Create(new UserEntity {ID = newUserID, Name = user.Name, PasswordHash = passwordHash});
        }
    }
}