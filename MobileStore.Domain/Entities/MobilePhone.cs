using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobileStore.Domain.Entities
{
    public class MobilePhone : IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("Name")]
        public string Name { get; set; }
        [Required]
        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public IEnumerable<Visual> Visuals { get; set; }
        [MaxLength(50)]
        public string Size { get; set; }
        [Required]
        [MaxLength(50)]
        public string Weight { get; set; }
        [Required]
        [MaxLength(50)]
        public string DisplayResolution { get; set; }
        [Required]
        [MaxLength(50)]
        public string Processor { get; set; }
        [Required]
        [MaxLength(50)]
        public string Memory { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ram { get; set; }
        [Required]
        [MaxLength(50)]
        public string OS { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    }
}
