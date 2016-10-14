using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Managers
{
    public class CounterManager : ICounterManager
    {
        private readonly ICounterRepository _counterRepository;
        private readonly ISessionContextHelper _sessionContextHelper;
        private readonly ISessionContextRepository _sessionContextRepository;

        public CounterManager(ICounterRepository counterRepository, ISessionContextRepository sessionContextRepository,
            ISessionContextHelper sessionContextHelper)
        {
            _counterRepository = counterRepository;
            _sessionContextRepository = sessionContextRepository;
            _sessionContextHelper = sessionContextHelper;
        }

        public void Add(Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.Create(new CounterEntity {Id = counter.Id, Type = counter.Type, UserId = counter.UserId});
        }

        public Counter[] FindAll()
        {
            //throw new NotImplementedException();
            return
                _counterRepository.FindAll()
                    .Select(counter => new Counter {Id = counter.Id, Type = counter.Type, UserId = counter.UserId})
                    .ToArray();
        }

        public Counter[] FindOwned(CounterType? counterType)
        {
            var userId = _sessionContextHelper.Instance.UserId;
            return
                _counterRepository.FindByUserId(userId, counterType)
                    .Select(counter => new Counter {Id = counter.Id, Type = counter.Type, UserId = counter.UserId})
                    .ToArray();
        }

        public void Remove(Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.DeleteById(counter.Id);
        }
    }
}