using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    interface ICounterRepository
    {
        [OperationContract]
        void Create(CounterEntity counterEntity);
        [OperationContract]
        void Update(CounterEntity counterEntity);
        [OperationContract]
        void Delete(CounterEntity counterEntity);
    }
}
