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

        public void DeleteById(int userId)
        {
            Channel.DeleteById(userId);
        }

        public UserEntity[] Find()
        {
            return Channel.Find();
        }

        public UserEntity FindById(int userId)
        {
            return Channel.FindById(userId);
        }

        public int GetFreeId()
        {
            return Channel.GetFreeId();
        }
    }
}