using System.Runtime.Serialization;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.Managers
{
    [DataContract]
    public class Counter
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public CounterType Type { get; set; }
    }
}