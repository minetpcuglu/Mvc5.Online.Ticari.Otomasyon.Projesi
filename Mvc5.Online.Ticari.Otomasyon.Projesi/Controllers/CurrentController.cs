using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class CurrentController : Controller
    {
        CurrentManager CM = new CurrentManager(new EfCurrentDal());
        // GET: Current

        public ActionResult Index()
        {
            var deger = CM.GetList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CurrentAdd(Current c)  // kuralları controllerda gercekleştirdik 
        {
            CM.CurrentAdd(c);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateCurrentPage(int id)
        {
            var deger = CM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateCurrentPage(Current d)
        {
            d.CurrentStatus = true;
            CM.UpdateCurrent(d);
            return RedirectToAction("Index");
        }

        public ActionResult CurrentDelete(int id)
        {
            var deger = CM.GetById(id);
            deger.CurrentStatus = false;
            CM.DeleteCurrent(deger);
            return RedirectToAction("Index");
        }

        public ActionResult CurrentPdf()
        {
            var deger = CM.GetList();
            return View(deger);
        }


    }
}