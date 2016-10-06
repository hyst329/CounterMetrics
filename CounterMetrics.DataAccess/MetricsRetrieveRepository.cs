using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.DataAccess
{
    class MetricsRetrieveRepository : IMetricsRetrieveRepository
    {
        private DatabaseContext databaseContext;

        public MetricsRetrieveRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public MetricEntity[] Find(CounterType? counterType, UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Find", this.GetType().FullName));
                int[] counters = this.databaseContext.CounterEntity.Where(counter => 
                (!counterType.HasValue || counter.Type == counterType.Value) && (userEntity == null || counter.UserID == userEntity.ID))
                .Select(counter => counter.ID).ToArray();
                return this.databaseContext.MetricEntity.Where(metric => counters.Contains(metric.CounterID)).ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public MetricEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, String.Format("DataAccess {0}: Find", this.GetType().FullName));
                return this.databaseContext.MetricEntity.Where(
                    metric => (!dateTimeStart.HasValue || metric.MetricDate >= dateTimeStart) && (!dateTimeEnd.HasValue || metric.MetricDate <= dateTimeEnd))
                    .ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }
    }
}
