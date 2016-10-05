using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    interface IUserRepository
    {
        [OperationContract]
        void Create(UserEntity userEntity);
        [OperationContract]
        void Update(UserEntity userEntity);
        [OperationContract]
        void Delete(UserEntity userEntity);
    }
}
