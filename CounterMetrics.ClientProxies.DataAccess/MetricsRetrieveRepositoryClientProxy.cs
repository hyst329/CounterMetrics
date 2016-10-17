using System;
using System.ServiceModel;
using System.Transactions;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class MetricsRetrieveRepositoryClientProxy : ClientBase<IMetricsRetrieveRepository>,
        IMetricsRetrieveRepository
    {
        //public MetricsRetrieveRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        //{
        //}

        public MetricEntity[] Find(CounterType? counterType, UserEntity userEntity)
        {
            MetricEntity[] metricEntities;
            using (var cf = new ChannelFactory<IMetricsRetrieveRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    metricEntities = ch.Find(counterType, userEntity);
                    scope.Complete();
                }
                cf.Close();
            }
            return metricEntities;
        }

        public MetricEntity[] FindAll()
        {
            MetricEntity[] metricEntities;
            using (var cf = new ChannelFactory<IMetricsRetrieveRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    metricEntities = ch.FindAll();
                    scope.Complete();
                }
                cf.Close();
            }
            return metricEntities;
        }

        public MetricEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd)
        {
            MetricEntity[] metricEntities;
            using (var cf = new ChannelFactory<IMetricsRetrieveRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    metricEntities = ch.FindByDate(dateTimeStart, dateTimeEnd);
                    scope.Complete();
                }
                cf.Close();
            }
            return metricEntities;
        }

        public MetricEntity[] FindUserMetricsForMonth(int userId, int monthNumber, int? yearNumber)
        {
            MetricEntity[] metricEntities;
            using (var cf = new ChannelFactory<IMetricsRetrieveRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    metricEntities = ch.FindUserMetricsForMonth(userId, monthNumber, yearNumber);
                    scope.Complete();
                }
                cf.Close();
            }
            return metricEntities;
        }
    }
}