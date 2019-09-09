using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.Domain.Entities;
using MobileStore.Service.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.WebUI.Models
{
    public class MobileSearchModel
    {
        [BindProperty]
        public List<SelectListItem> Manufacturers { get; private set; }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public decimal? StartPrice { get; set; }
        [BindProperty]
        public decimal? EndPrice { get; set; }
        [BindProperty]
        public int ManufacturerID { get; set; }

        public MobileSearchModel(List<SelectListItem> manufacturers)
        {
            Manufacturers = manufacturers;
        }
    }
}
