using System;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Managers
{
    internal class MetricsManager : IMetricsManager
    {
        public void Add(Metric metric)
        {
            throw new NotImplementedException();
        }

        public Metric[] Find()
        {
            throw new NotImplementedException();
        }

        public Metric[] FindByDate(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public Metric[] FindByType(int? userID, CounterType? counterType)
        {
            throw new NotImplementedException();
        }

        public Metric[] GetStaticticsForMonth(int monthNumber, int? yearNumber = default(int?))
        {
            throw new NotImplementedException();
        }
    }
}