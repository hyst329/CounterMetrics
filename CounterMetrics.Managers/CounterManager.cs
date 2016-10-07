using System;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Managers
{
    public class CounterManager : ICounterManager
    {
        public void Add(Counter counter)
        {
            throw new NotImplementedException();
        }

        public Counter[] FindAll()
        {
            throw new NotImplementedException();
        }

        public Counter[] FindByUserId(int userId, CounterType? counterType)
        {
            throw new NotImplementedException();
        }

        public void Remove(Counter counter)
        {
            throw new NotImplementedException();
        }
    }
}