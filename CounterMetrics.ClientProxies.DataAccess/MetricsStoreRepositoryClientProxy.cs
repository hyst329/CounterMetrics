using System.ServiceModel;
using CounterMetrics.Contracts.DataAccess;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class MetricsStoreRepositoryClientProxy : ClientBase<IMetricsStoreRepository>, IMetricsStoreRepository
    {
        //public MetricsStoreRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        //{
        //}

        public void Persist(MetricEntity metricEntity)
        {
            //using (var cf = new ChannelFactory<IMetricsStoreRepository>())
            //{
            //    var ch = cf.CreateChannel();
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required))
            //    {
            //        ch.Persist(metricEntity);
            //        scope.Complete();
            //    }
            //    cf.Close();
            //}
            Channel.Persist(metricEntity);
        }
    }
}