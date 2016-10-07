using System;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    public struct LoginData
    {
        public Guid Guid { get; set; }
        public int UserId { get; set; }
    };

    [ServiceContract]
    public interface IAuthManager
    {
        [OperationContract]
        LoginData? Login(User user);

        [OperationContract]
        void Logout(Guid sessionGuid);

        [OperationContract]
        int? GetLoggedInUserId(Guid sessionGuid);
    }
}