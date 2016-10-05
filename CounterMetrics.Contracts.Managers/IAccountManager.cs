using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    public interface IAccountManager
    {
        [OperationContract]
        void Register(User user);
    }
}
