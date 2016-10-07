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

        public void DeleteByID(int counterID)
        {
            Channel.DeleteByID(counterID);
        }

        public CounterEntity FindByID(int counterID)
        {
            return Channel.FindByID(counterID);
        }

        public CounterEntity[] FindByUserID(int userID)
        {
            return Channel.FindByUserID(userID);
        }
    }
}