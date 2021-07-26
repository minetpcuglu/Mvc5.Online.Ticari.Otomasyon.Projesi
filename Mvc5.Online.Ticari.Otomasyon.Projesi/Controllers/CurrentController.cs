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
        public ActionResult CategoryAdd(Current c)  //VALİDATOR kuralları controllerda gercekleştirdik 
        {


            CM.CurrentAdd(c);
            return RedirectToAction("Index");


        }


    }
}