using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.Managers
{
    public class AccountManager : IAccountManager
    {
        private UserRepository userRepository;

        public AccountManager(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Register(User user)
        {
            //throw new NotImplementedException();
            int newUserID = this.userRepository.GetFreeID();
            string passwordHash = ServiceLocator.Hasher.Hash(user.Password);
            this.userRepository.Create(new UserEntity { ID = newUserID, Name = user.Name, PasswordHash = passwordHash });
        }
    }
}
