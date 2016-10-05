using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    interface IMetricsManager
    {
        [OperationContract]
        void Add(Metric metric);
        [OperationContract]
        void FindByType(int userID, DataAccess.CounterType? counterType);
        [OperationContract]
        void FindByDate(DateTime? startDate, DateTime? endDate);
    }
}
