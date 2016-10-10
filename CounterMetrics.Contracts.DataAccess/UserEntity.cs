using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CounterMetrics.Contracts.DataAccess
{
    [Table("Users")]
    [DataContract]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PasswordHash { get; set; }
    }
}