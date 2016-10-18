using System;
using System.ServiceModel;
using CounterMetrics.Contracts.Managers;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.ClientProxies.Managers
{
    public class MetricsManagerClientProxy : ClientBase<IMetricsManager>, IMetricsManager
    {
        public void Add(Metric metric)
        {
            Channel.Add(metric);
        }

        public Metric[] Find()
        {
            return Channel.Find();
        }

        public Metric[] FindByDate(DateTime? startDate, DateTime? endDate)
        {
            return Channel.FindByDate(startDate, endDate);
        }

        public Metric[] GetStaticticsForMonth(int monthNumber, int? yearNumber = null)
        {
            return Channel.GetStaticticsForMonth(monthNumber, yearNumber);
        }

        public Metric[] FindByType(CounterType? counterType)
        {
            return Channel.FindByType(counterType);
        }
    }
}