using System;
using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IMetricsRetrieveRepository
    {
        [OperationContract]
        MetricEntity[] Find(CounterType? counterType, UserEntity userEntity);

        [OperationContract]
        MetricEntity[] FindAll();

        [OperationContract]
        MetricEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd);

        [OperationContract]
        MetricEntity[] FindUserMetricsForMonth(int userId, int monthNumber, int? yearNumber);
    }
}