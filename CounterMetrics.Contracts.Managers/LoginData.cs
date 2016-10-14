using System;
using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.Managers
{
    [DataContract]
    public class LoginData
    {
        [DataMember]
        public Guid SessionGuid { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}