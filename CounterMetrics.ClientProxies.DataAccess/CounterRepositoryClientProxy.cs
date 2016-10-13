using System.ServiceModel;
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
            Channel.Create(counterEntity);
        }

        public void DeleteById(int counterId)
        {
            Channel.DeleteById(counterId);
        }

        public CounterEntity[] FindAll()
        {
            return Channel.FindAll();
        }

        public CounterEntity FindById(int counterId)
        {
            return Channel.FindById(counterId);
        }

        public CounterEntity[] FindByUserId(int userId, CounterType? counterType)
        {
            return Channel.FindByUserId(userId, counterType);
        }
    }
}