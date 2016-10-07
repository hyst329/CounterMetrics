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