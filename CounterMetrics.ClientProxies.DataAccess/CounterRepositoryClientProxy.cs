using System.ServiceModel;
using System.Transactions;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class CounterRepositoryClientProxy : ClientBase<ICounterRepository>, ICounterRepository
    {
        public CounterRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public void Create(CounterEntity counterEntity)
        {
            using (var cf = new ChannelFactory<ICounterRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    ch.Create(counterEntity);
                    scope.Complete();
                }
                cf.Close();
            }
        }

        public void DeleteById(int counterId)
        {
            using (var cf = new ChannelFactory<ICounterRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    ch.DeleteById(counterId);
                    scope.Complete();
                }
                cf.Close();
            }
        }

        public CounterEntity[] FindAll()
        {
            CounterEntity[] counterEntities;
            using (var cf = new ChannelFactory<ICounterRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    counterEntities = ch.FindAll();
                    scope.Complete();
                }
                cf.Close();
            }
            return counterEntities;
        }

        public CounterEntity FindById(int counterId)
        {
            CounterEntity counterEntity;
            using (var cf = new ChannelFactory<ICounterRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    counterEntity = ch.FindById(counterId);
                    scope.Complete();
                }
                cf.Close();
            }
            return counterEntity;
        }

        public CounterEntity[] FindByUserId(int userId, CounterType? counterType)
        {
            CounterEntity[] counterEntities;
            using (var cf = new ChannelFactory<ICounterRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    counterEntities = ch.FindByUserId(userId, counterType);
                    scope.Complete();
                }
                cf.Close();
            }
            return counterEntities;
        }
    }
}