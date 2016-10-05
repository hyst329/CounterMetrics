﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CounterMetrics.Contracts.Managers
{
    [ServiceContract]
    interface IAuthManager
    {
        [OperationContract]
        void Login(User user);
        [OperationContract]
        void Logout();
    }
}
