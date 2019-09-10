using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
