using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IMetricsManager
    {
        [OperationContract]
        void Add(Metric metric);
        [OperationContract]
        Metric[] FindByType(int? userID, DataAccess.CounterType? counterType);
        [OperationContract]
        Metric[] Find();
        [OperationContract]
        Metric[] FindByDate(DateTime? startDate, DateTime? endDate);
        [OperationContract]
        Metric[] GetStaticticsForMonth(int monthNumber, int? yearNumber = null);
    }
}
