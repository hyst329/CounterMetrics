using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CounterMetrics.Contracts.Managers
{
    [DataContract]
    public class Metric
    {
        [DataMember]
        public int CounterID { get; set; }
        [DataMember]
        public decimal MetricValue { get; set; }
    }
}
