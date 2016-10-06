using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;
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
            
        }
    }
}
