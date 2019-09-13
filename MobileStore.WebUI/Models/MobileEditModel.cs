using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.WebUI.Models
{
    public class MobileEditModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
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
        [Required]
        public decimal Price { get; set; }
        public IFormFile Thumbnail { get; set; }
        public IEnumerable<IFormFile> Visuals { get; set; }

        public IEnumerable<SelectListItem> Manufacturers { get; private set; }

        public MobileEditModel()
        {

        }
        public MobileEditModel(IEnumerable<Manufacturer> manufacturers)
        {
            Manufacturers = manufacturers.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ID.ToString()
            });
        }
    }
}