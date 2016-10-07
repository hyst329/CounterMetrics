using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class CounterRepositoryClientProxy : ClientBase<ICounterRepository>, ICounterRepository
    {
        public void Create(CounterEntity counterEntity)
        {
            Channel.Create(counterEntity);
        }

        public void DeleteById(int counterId)
        {
            Channel.DeleteById(counterId);
        }

        public CounterEntity FindById(int counterId)
        {
            return Channel.FindById(counterId);
        }

        public CounterEntity[] FindByUserId(int userId)
        {
            return Channel.FindByUserId(userId);
        }
    }
}