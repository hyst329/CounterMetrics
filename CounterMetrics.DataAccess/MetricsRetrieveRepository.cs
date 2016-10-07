using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    internal class MetricsRetrieveRepository : IMetricsRetrieveRepository
    {
        private readonly DatabaseContext databaseContext;

        public MetricsRetrieveRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public MetricEntity[] Find(CounterType? counterType, UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Find", GetType().FullName));
                var counters = databaseContext.CounterEntity.Where(counter =>
                        (!counterType.HasValue || (counter.Type == counterType.Value)) &&
                        ((userEntity == null) || (counter.UserID == userEntity.ID)))
                    .Select(counter => counter.ID).ToArray();
                return databaseContext.MetricEntity.Where(metric => counters.Contains(metric.CounterID)).ToArray();
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
                ServiceLocator.Logger.Log(LogSeverity.Info, string.Format("DataAccess {0}: Find", GetType().FullName));
                return databaseContext.MetricEntity.Where(
                        metric =>
                            (!dateTimeStart.HasValue || (metric.MetricDate >= dateTimeStart)) &&
                            (!dateTimeEnd.HasValue || (metric.MetricDate <= dateTimeEnd)))
                    .ToArray();
            }
            catch (Exception e)
            {
                ServiceLocator.Logger.Log(LogSeverity.Error, e.Message);
                throw;
            }
        }

        public MetricEntity[] FindUserMetricsForMonth(int userID, int monthNumber, int? yearNumber)
        {
            //throw new NotImplementedException();
            try
            {
                var now = DateTime.Now;
                if (yearNumber == null) yearNumber = now.Month >= monthNumber ? now.Year : now.Year - 1;
                return
                    databaseContext.MetricEntity.Where(
                            metric => (metric.MetricDate.Year == yearNumber) && (metric.MetricDate.Month == monthNumber))
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