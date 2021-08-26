using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class CargoController : Controller
    {
        CargoDetailManager CDM = new CargoDetailManager(new EfCargoDetailDal());
      
        // GET: Cargo
        public ActionResult Index(string p  )
        {
            var deger = from x in CDM.GetList() select x;
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.TrackingCode.Contains(p));
            }
            return View(deger.ToList());
        }
        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D","E","F","G","L","P","O" };
            int k1, k2, k3;
            k1 = rnd.Next(0,karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = code;
            return View();
        }


        [HttpPost]
        public ActionResult CargoAdd(CargoDetail c)  // kuralları controllerda gercekleştirdik 
        {
            CDM.CargoDetailAdd(c);
            return RedirectToAction("Index");

        }


    }
}