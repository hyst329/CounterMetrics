using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.Managers
{
    [DataContract]
    public class Metric
    {
        [DataMember]
        public int CounterId { get; set; }

        [DataMember]
        public decimal MetricValue { get; set; }
    }
}