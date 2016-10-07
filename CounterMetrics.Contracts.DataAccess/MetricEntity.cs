using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Metrics")]
    [DataContract]
    public class MetricEntity
    {
        [DataMember]
        public int CounterId { get; set; }

        [DataMember]
        public decimal MetricValue { get; set; }

        [DataMember]
        public DateTime MetricDate { get; set; }
    }
}