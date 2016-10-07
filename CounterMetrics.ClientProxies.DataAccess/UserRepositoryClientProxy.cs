using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

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

        public UserEntity[] Find()
        {
            return Channel.Find();
        }

        public UserEntity FindByID(int userID)
        {
            return Channel.FindByID(userID);
        }

        public int GetFreeID()
        {
            return Channel.GetFreeID();
        }
    }
}