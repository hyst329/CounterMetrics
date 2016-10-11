using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface ISessionContextRepository
    {
        [OperationContract]
        int? GetUserId(Guid sessionGuid);
        [OperationContract]
        ISessionContext Add(int userId);
        [OperationContract]
        void Remove(Guid sessionGuid);
    }
}
