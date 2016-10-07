using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.Managers
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}