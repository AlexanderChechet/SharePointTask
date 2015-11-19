using BLL.Interface.Services;
using MvcL.Mappers;
using MvcL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcL.Controllers
{
    public class HomeController : Controller
    {
        private ITestListService testListService;

        public HomeController(ITestListService tls)
        {
            testListService = tls;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var testList = testListService.GetAllItems().Select(x => x.ToTestListItemModel());
            return View(testList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestListItemModel model)
        {
            if (ModelState.IsValid)
            {
                testListService.AddItem(model.ToTestListItemEntity());
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var item = testListService.GetItem(id).ToTestListItemModel();
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = testListService.GetItem(id).ToTestListItemModel();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TestListItemModel model)
        {
            if (ModelState.IsValid)
            {
                testListService.UpdateItem(model.ToTestListItemEntity());
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = testListService.GetItem(id).ToTestListItemModel();
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(TestListItemModel model)
        {
            testListService.DeleteItem(model.Id);
            return RedirectToAction("Index");
        }



    }
}
