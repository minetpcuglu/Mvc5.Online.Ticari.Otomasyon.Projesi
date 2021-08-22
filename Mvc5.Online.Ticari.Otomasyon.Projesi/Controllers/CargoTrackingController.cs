using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class CargoTrackingController : Controller
    {
        // GET: CargoTracking
        CargoTrackingManager TCM = new CargoTrackingManager(new EfCargoTrackingDal());
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargoDetail(string id) //route config detayı id yapıldı
        {
            var deger = TCM.GetListCargoDetail(id);
            return View(deger);
        }
    }
}