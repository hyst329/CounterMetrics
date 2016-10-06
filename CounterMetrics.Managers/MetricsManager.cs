using CounterMetrics.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.Managers
{
    class MetricsManager : IMetricsManager
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
