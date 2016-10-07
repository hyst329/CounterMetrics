using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.DataAccess
{
    internal class MetricsRetrieveRepository : IMetricsRetrieveRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MetricsRetrieveRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public MetricEntity[] Find(CounterType? counterType, UserEntity userEntity)
        {
            //throw new NotImplementedException();
            try
            {
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Find");
                var counters = _databaseContext.CounterEntity.Where(counter =>
                        (!counterType.HasValue || (counter.Type == counterType.Value)) &&
                        ((userEntity == null) || (counter.UserId == userEntity.Id)))
                    .Select(counter => counter.Id).ToArray();
                return _databaseContext.MetricEntity.Where(metric => counters.Contains(metric.CounterId)).ToArray();
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
                ServiceLocator.Logger.Log(LogSeverity.Info, $"DataAccess {GetType().FullName}: Find");
                return _databaseContext.MetricEntity.Where(
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

        public MetricEntity[] FindUserMetricsForMonth(int userId, int monthNumber, int? yearNumber)
        {
            //throw new NotImplementedException();
            try
            {
                var now = DateTime.Now;
                if (yearNumber == null) yearNumber = now.Month >= monthNumber ? now.Year : now.Year - 1;
                return
                    _databaseContext.MetricEntity.Where(
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