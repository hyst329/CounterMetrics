using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IMetricsRetrieveRepository
    {
        [OperationContract]
        MetricEntity[] Find(CounterType? counterType, UserEntity userEntity);
        [OperationContract]
        MetricEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd);
        [OperationContract]
        MetricEntity[] FindUserMetricsForMonth(int userID, int monthNumber, int? yearNumber);
    }
}
