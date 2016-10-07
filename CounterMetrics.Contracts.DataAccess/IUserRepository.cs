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