using System;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    internal class MetricsStoreRepository : IMetricsStoreRepository
    {
        private readonly DatabaseContext databaseContext;

        public MetricsStoreRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Persist(MetricEntity metricEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Persist", GetType().FullName));
                databaseContext.MetricEntity.Add(metricEntity);
                databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                string.Format("Created metric of type {0} with value {1} and date {2}",
                    metricEntity.CounterID, metricEntity.MetricValue, metricEntity.MetricDate));
        }
    }
}