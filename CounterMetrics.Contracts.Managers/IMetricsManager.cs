using System;
using System.ServiceModel;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IMetricsManager
    {
        [OperationContract]
        void Add(Metric metric);

        [OperationContract]
        Metric[] FindByType(CounterType? counterType);

        [OperationContract]
        Metric[] Find();

        [OperationContract]
        Metric[] FindByDate(DateTime? startDate, DateTime? endDate);

        [OperationContract]
        Metric[] GetStaticticsForMonth(int monthNumber, int? yearNumber = null);
    }
}