using CounterMetrics.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterMetrics.Contracts.DataAccess;

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

        public Counter[] FindByUserID(int userID, CounterType? counterType)
        {
            throw new NotImplementedException();
        }

        public void Remove(Counter counter)
        {
            throw new NotImplementedException();
        }
    }
}
