using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class MetricsStoreRepositoryClientProxy : ClientBase<IMetricsStoreRepository>, IMetricsStoreRepository
    {
        public void Persist(MetricEntity metricEntity)
        {
            Channel.Persist(metricEntity);
        }
    }
}