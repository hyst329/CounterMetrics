using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IMetricsStoreRepository
    {
        [OperationContract(IsOneWay = true)]
        void Persist(MetricEntity metricEntity);
    }
}