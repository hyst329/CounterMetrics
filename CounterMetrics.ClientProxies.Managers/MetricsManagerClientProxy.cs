using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.ClientProxies.Managers
{
    public class MetricsManagerClientProxy : ClientBase<IMetricsManager>, IMetricsManager
    {
        public void Add(Guid sessionGuid, Metric metric)
        {
            Channel.Add(sessionGuid, metric);
        }

        public Metric[] Find(Guid sessionGuid)
        {
            return Channel.Find(sessionGuid);
        }

        public Metric[] FindByDate(Guid sessionGuid, DateTime? startDate, DateTime? endDate)
        {
            return Channel.FindByDate(sessionGuid, startDate, endDate);
        }

        public Metric[] GetStaticticsForMonth(Guid sessionGuid, int monthNumber, int? yearNumber = null)
        {
            return Channel.GetStaticticsForMonth(sessionGuid, monthNumber, yearNumber);
        }

        public Metric[] FindByType(Guid sessionGuid, CounterType? counterType)
        {
            return Channel.FindByType(sessionGuid, counterType);
        }
    }
}