using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Domain.Entities
{
    public class Manufacturer : IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("Name")]
        public string Name { get; set; }
        public IEnumerable<MobilePhone> MobilePhones { get; set; }
    }
}
