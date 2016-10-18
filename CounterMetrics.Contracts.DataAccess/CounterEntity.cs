using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Counters")]
    [DataContract]
    public class CounterEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        [DataMember]
        public CounterType Type { get; set; }
    }
}