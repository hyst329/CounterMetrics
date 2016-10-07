using System.ServiceModel;

namespace CounterMetrics.Contracts.DataAccess
{
    [ServiceContract]
    public interface ICounterRepository
    {
        [OperationContract]
        void Create(CounterEntity counterEntity);

        [OperationContract]
        void DeleteById(int counterId);

        [OperationContract]
        CounterEntity FindById(int counterId);

        [OperationContract]
        CounterEntity[] FindAll();

        [OperationContract]
        CounterEntity[] FindByUserId(int userId, CounterType? counterType);
    }
}