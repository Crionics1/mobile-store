﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Domain.Entities;
using MobileStore.Service.InterFaces;
using MobileStore.WebUI.Models;
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

        public async Task<IActionResult> Index(MobileSearchModel mobileSearchModel, int page = 1)
        {
            if (mobileSearchModel == null)
            {
                var items = _service.GetAll(true, true);
                var model = await PaginatedList<MobilePhone>.CreateAsync(items, page, 6);

                return View(model);
            }

            ViewData["name"] = mobileSearchModel.Name;
            ViewData["startPrice"] = mobileSearchModel.StartPrice;
            ViewData["endPrice"] = mobileSearchModel.EndPrice;
            ViewData["manufacturerID"] = mobileSearchModel.ManufacturerID;

            var filteredItems = _service.Search(mobileSearchModel.Name, mobileSearchModel.StartPrice, mobileSearchModel.EndPrice, mobileSearchModel.ManufacturerID);
            var filteredModel = await PaginatedList<MobilePhone>.CreateAsync(filteredItems, page, 6);

            return View("Index", filteredModel);
        }

        public IActionResult Details(int id)
        {
            var item = _service.Get(id);
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