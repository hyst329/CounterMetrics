using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Metrics")]
    [DataContract]
    public class MetricEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CounterId { get; set; }

        [DataMember]
        public decimal MetricValue { get; set; }

        [DataMember]
        public DateTime MetricDate { get; set; }
    }
}