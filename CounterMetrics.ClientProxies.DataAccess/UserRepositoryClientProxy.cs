using System.ServiceModel;
using System.Transactions;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class UserRepositoryClientProxy : ClientBase<IUserRepository>, IUserRepository
    {
        //public UserRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        //{
        //}

        public void Create(UserEntity userEntity)
        {
            //using (var cf = new ChannelFactory<IUserRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        ch.Create(userEntity);
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            Channel.Create(userEntity);
        }

        public void DeleteById(int userId)
        {
            //using (var cf = new ChannelFactory<IUserRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        ch.DeleteById(userId);
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            Channel.DeleteById(userId);
        }

        public UserEntity[] Find()
        {
            //UserEntity[] userEntities;
            //using (var cf = new ChannelFactory<IUserRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        userEntities = ch.Find();
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            //return userEntities;
            return Channel.Find();
        }

        public UserEntity FindById(int userId)
        {
            //UserEntity userEntity;
            //using (var cf = new ChannelFactory<IUserRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        userEntity = ch.FindById(userId);
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            //return userEntity;
            return Channel.FindById(userId);
        }

        public int GetFreeId()
        {
            //int id;
            //using (var cf = new ChannelFactory<IUserRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        id = ch.GetFreeId();
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            //return id;
            return Channel.GetFreeId();
        }
    }
}