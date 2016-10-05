using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Metrics")]
    [DataContract]
    public class MetricEntity
    {
        [DataMember]
        public int CounterID { get; set; }
        [DataMember]
        public decimal MetricValue { get; set; }
        [DataMember]
        public DateTime MetricDate { get; set; }
    }
}
