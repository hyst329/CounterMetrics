using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterMetrics.Contracts.DataAccess;
using System.ServiceModel;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class UserRepositoryClientProxy : ClientBase<IUserRepository>, IUserRepository
    {
        public void Create(UserEntity userEntity)
        {
            Channel.Create(userEntity);
        }

        public void DeleteByID(int userID)
        {
            Channel.DeleteByID(userID);
        }

        public int GetFreeID()
        {
            return Channel.GetFreeID();
        }
    }
}
