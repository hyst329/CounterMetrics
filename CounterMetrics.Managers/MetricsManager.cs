using System;
using System.Linq;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Contracts.Managers;

namespace CounterMetrics.Managers
{
    public class MetricsManager : IMetricsManager
    {
        private readonly IMetricsRetrieveRepository _metricsRetrieveRepository;
        private readonly IMetricsStoreRepository _metricsStoreRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISessionContextRepository _sessionContextRepository;

        public MetricsManager(IMetricsStoreRepository metricsStoreRepository,
            IMetricsRetrieveRepository metricsRetrieveRepository, IUserRepository userRepository, ISessionContextRepository sessionContextRepository)
        {
            _metricsStoreRepository = metricsStoreRepository;
            _metricsRetrieveRepository = metricsRetrieveRepository;
            _userRepository = userRepository;
            _sessionContextRepository = sessionContextRepository;
        }

        public void Add(Guid sessionGuid, Metric metric)
        {
            _metricsStoreRepository.Persist(new MetricEntity
            {
                CounterId = metric.CounterId,
                MetricDate = DateTime.Now,
                MetricValue = metric.MetricValue
            });
        }

        public Metric[] Find(Guid sessionGuid)
        {
            return
                _metricsRetrieveRepository.FindAll()
                    .Select(
                        metricEntity =>
                            new Metric
                            {
                                CounterId = metricEntity.CounterId,
                                MetricDate = metricEntity.MetricDate,
                                MetricValue = metricEntity.MetricValue
                            })
                    .ToArray();
        }

        public Metric[] FindByDate(Guid sessionGuid, DateTime? startDate, DateTime? endDate)
        {
            //throw new NotImplementedException();
            return _metricsRetrieveRepository.FindByDate(startDate, endDate).Select(
                        metricEntity =>
                            new Metric
                            {
                                CounterId = metricEntity.CounterId,
                                MetricDate = metricEntity.MetricDate,
                                MetricValue = metricEntity.MetricValue
                            })
                    .ToArray();
        }

        public Metric[] FindByType(Guid sessionGuid, CounterType? counterType)
        {
            //if (userId == null) return Find(sessionGuid);
            int? userId = _sessionContextRepository.GetUserId(sessionGuid);
            var userEntity = _userRepository.FindById(userId.Value);
            return
                _metricsRetrieveRepository.Find(counterType, userEntity)
                    .Select(
                        metricEntity =>
                            new Metric
                            {
                                CounterId = metricEntity.CounterId,
                                MetricDate = metricEntity.MetricDate,
                                MetricValue = metricEntity.MetricValue
                            })
                    .ToArray();
        }

        public Metric[] GetStaticticsForMonth(Guid sessionGuid, int monthNumber, int? yearNumber = null)
        {
            var now = DateTime.Now;
            if (yearNumber == null) yearNumber = monthNumber > now.Month ? now.Year - 1 : now.Year;
            var dateTimeStart = new DateTime(yearNumber.Value, monthNumber, 1);
            var dateTimeEnd = new DateTime(yearNumber.Value, monthNumber + 1, 1).AddMilliseconds(-1);
            return
                _metricsRetrieveRepository.FindByDate(dateTimeStart, dateTimeEnd)
                    .Select(
                        metricEntity =>
                            new Metric
                            {
                                CounterId = metricEntity.CounterId,
                                MetricDate = metricEntity.MetricDate,
                                MetricValue = metricEntity.MetricValue
                            })
                    .ToArray();
        }
    }
}