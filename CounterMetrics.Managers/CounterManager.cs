using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.DataAccess;

namespace CounterMetrics.Managers
{
    public class CounterManager : ICounterManager
    {
        private readonly CounterRepository _counterRepository;
        public CounterManager(CounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }
        public void Add(Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.Create(new CounterEntity { Id = counter.Id, Type = counter.Type, UserId = counter.UserId });
        }

        public Counter[] FindAll()
        {
            //throw new NotImplementedException();
            return _counterRepository.FindAll().Select(counter => new Counter { Id = counter.Id, Type = counter.Type, UserId = counter.UserId }).ToArray();
        }

        public Counter[] FindByUserId(int userId, CounterType? counterType)
        {
            return _counterRepository.FindByUserId(userId, counterType).Select(counter => new Counter { Id = counter.Id, Type = counter.Type, UserId = counter.UserId }).ToArray();
        }

        public void Remove(Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.DeleteById(counter.Id);
        }
    }
}