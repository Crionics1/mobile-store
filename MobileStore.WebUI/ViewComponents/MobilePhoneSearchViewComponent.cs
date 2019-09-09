using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.Service.InterFaces;
using MobileStore.WebUI.Models;
using System.Linq;

namespace MobileStore.WebUI.ViewComponents
{
    public class MobilePhoneSearchViewComponent : ViewComponent
    {
        private IManufacturerService _manufacturerService;
        [BindProperty]
        public UserModel UserModel { get; set; }

        public MobilePhoneSearchViewComponent(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public IViewComponentResult Invoke()
        {
            var manufacturers = _manufacturerService.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.ID.ToString()
            });

            var list = manufacturers.ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "Select Manufacturer",
                Value = "0"
            });

            UserModel = new UserModel(list);
            return View("_Default", UserModel);
        }
    }
}
