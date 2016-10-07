using System;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    internal class MetricsStoreRepository : IMetricsStoreRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MetricsStoreRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Persist(MetricEntity metricEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Persist");
                _databaseContext.MetricEntity.Add(metricEntity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info,
                $"Created metric of type {metricEntity.CounterId} with value {metricEntity.MetricValue} and date {metricEntity.MetricDate}");
        }
    }
}