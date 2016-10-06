using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.DataAccess
{
    class MetricsStoreRepository : IMetricsStoreRepository
    {
        private DatabaseContext databaseContext;

        public MetricsStoreRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Persist(MetricEntity metricEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Persist", this.GetType().FullName));
                this.databaseContext.MetricEntity.Add(metricEntity);
                this.databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
            ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("Created metric of type {0} with value {1} and date {2}",
                metricEntity.CounterID, metricEntity.MetricValue, metricEntity.MetricDate));
        }
    }
}
