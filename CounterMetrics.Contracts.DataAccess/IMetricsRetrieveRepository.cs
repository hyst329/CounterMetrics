using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    interface IMetricsRetrieveRepository
    {
        [OperationContract]
        CounterEntity[] Find(CounterType? counterType, UserEntity userEntity);
        [OperationContract]
        CounterEntity[] FindByDate(DateTime? dateTimeStart, DateTime? dateTimeEnd);
    }
}
