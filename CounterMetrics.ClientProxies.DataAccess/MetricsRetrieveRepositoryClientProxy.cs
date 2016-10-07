using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class MetricsRetrieveRepositoryClientProxy : ClientBase<IMetricsRetrieveRepository>,
        IMetricsRetrieveRepository
    {
        public MetricEntity[] Find(CounterType? counterType, UserEntity userEntity)
        {
            return Channel.Find(counterType, userEntity);
        }

        public MetricEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd)
        {
            return Channel.FindByDate(dateTimeStart, dateTimeEnd);
        }

        public MetricEntity[] FindUserMetricsForMonth(int userId, int monthNumber, int? yearNumber)
        {
            return Channel.FindUserMetricsForMonth(userId, monthNumber, yearNumber);
        }
    }
}