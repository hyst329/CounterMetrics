using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IUserRepository
    {
        [OperationContract]
        void Create(UserEntity userEntity);
        [OperationContract]
        UserEntity FindByID(int userID);
        [OperationContract]
        void DeleteByID(int userID);
        [OperationContract]
        UserEntity[] Find();
        [OperationContract]
        int GetFreeID();
    }
}
