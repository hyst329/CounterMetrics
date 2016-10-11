using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Managers
{
    public class CounterManager : ICounterManager
    {
        private readonly ICounterRepository _counterRepository;
        private readonly ISessionContextRepository _sessionContextRepository;

        public CounterManager(ICounterRepository counterRepository, ISessionContextRepository sessionContextRepository)
        {
            _counterRepository = counterRepository;
            _sessionContextRepository = sessionContextRepository;
        }

        public void Add(Guid sessionGuid, Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.Create(new CounterEntity {Id = counter.Id, Type = counter.Type, UserId = counter.UserId});
        }

        public Counter[] FindAll(Guid sessionGuid)
        {
            //throw new NotImplementedException();
            return
                _counterRepository.FindAll()
                    .Select(counter => new Counter {Id = counter.Id, Type = counter.Type, UserId = counter.UserId})
                    .ToArray();
        }

        public Counter[] FindOwned(Guid sessionGuid, CounterType? counterType)
        {
            int? userId = _sessionContextRepository.GetUserId(sessionGuid);
            if (!userId.HasValue) return default(Counter[]);
            return
                _counterRepository.FindByUserId(userId.Value, counterType)
                    .Select(counter => new Counter {Id = counter.Id, Type = counter.Type, UserId = counter.UserId})
                    .ToArray();
        }

        public void Remove(Guid sessionGuid, Counter counter)
        {
            //throw new NotImplementedException();
            _counterRepository.DeleteById(counter.Id);
        }
    }
}