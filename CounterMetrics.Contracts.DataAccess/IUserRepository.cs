using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface IUserRepository
    {
        [OperationContract]
        void Create(UserEntity userEntity);

        [OperationContract]
        UserEntity FindById(int userId);

        [OperationContract]
        void DeleteById(int userId);

        [OperationContract]
        UserEntity[] Find();

        [OperationContract]
        int GetFreeId();
    }
}