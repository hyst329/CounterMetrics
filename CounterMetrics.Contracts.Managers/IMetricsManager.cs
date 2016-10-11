using System;
using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IMetricsManager
    {
        [OperationContract]
        void Add(Guid sessionGuid, Metric metric);

        [OperationContract]
        Metric[] FindByType(Guid sessionGuid, CounterType? counterType);

        [OperationContract]
        Metric[] Find(Guid sessionGuid);

        [OperationContract]
        Metric[] FindByDate(Guid sessionGuid, DateTime? startDate, DateTime? endDate);

        [OperationContract]
        Metric[] GetStaticticsForMonth(Guid sessionGuid, int monthNumber, int? yearNumber = null);
    }
}