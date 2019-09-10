using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Domain.Entities;
using MobileStore.Repository;
using MobileStore.Repository.Interfaces;
using MobileStore.Service.InterFaces;
using MobileStore.WebUI.Paging;

namespace MobileStore.WebUI.Controllers
{
    public class MobilePhonesController : Controller
    {
        private IMobilePhoneService _service;
        private IService<Visual> _visualService;
        public MobilePhonesController(IMobilePhoneService service, IService<Visual> visualService)
        {
            _service = service;
            _visualService = visualService;
        }

        public async Task<IActionResult> Index(string name, decimal? startPrice, decimal? endPrice, int manufacturerID, int page = 1)
        {
            if (name == null && startPrice == null && endPrice == null && manufacturerID == 0)
            {
                var items = _service.GetAll(true, true);
                var model = await PaginatedList<MobilePhone>.CreateAsync(items, page, 6);
                return View(model);
            }

            ViewData["name"] = name;
            ViewData["startPrice"] = startPrice;
            ViewData["endPrice"] = endPrice;
            ViewData["manufacturerID"] = manufacturerID;

            var filteredItems = _service.Search(name, startPrice, endPrice, manufacturerID);
            var filteredModel = await PaginatedList<MobilePhone>.CreateAsync(filteredItems, page, 6);

            return View("Index", filteredModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetAsync(id);
            if (item == null)
            {
                return View("NotFound");
            }
            return View(item);
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var mobile = await _service.GetAsync(id);
        //    return View(mobile);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(MobilePhone mobilePhone, List<IFormFile> files)
        //{

        //    long size = files.Sum(f => f.Length);

        //    var file = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
        //    var filePath = Path.Combine(new string[] { "~/", "visuals", file });

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    try
        //    {
        //        await _service.UpdateAsync(mobilePhone);
        //        return RedirectToAction("Details", mobilePhone.ID);
        //    }
        //    catch (Exception)
        //    {
        //        return View("Error");
        //    }
        //}
    }
}