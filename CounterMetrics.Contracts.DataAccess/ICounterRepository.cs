using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface ICounterRepository
    {
        [OperationContract]
        void Create(CounterEntity counterEntity);
        [OperationContract]
        void DeleteByID(int counterID);
        [OperationContract]
        CounterEntity FindByID(int counterID);
        [OperationContract]
        CounterEntity[] FindByUserID(int userID);
    }
}
