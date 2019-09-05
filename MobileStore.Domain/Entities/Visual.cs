using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileStore.Domain.Entities
{
    public class Visual : IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Path { get; set; }
        public MobilePhone MobilePhone { get; set; }
        [Required]
        public int MobilePhoneID { get; set; }
    }
}
