using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MobileStore.WebUI.Models
{
    public class MobileSearchModel
    {
        public List<SelectListItem> Manufacturers { get; private set; }

        public string Name { get; set; }
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
        public int ManufacturerID { get; set; }

        public MobileSearchModel()
        {

        }
        public MobileSearchModel(List<SelectListItem> manufacturers)
        {
            Manufacturers = manufacturers;
        }
    }
}
