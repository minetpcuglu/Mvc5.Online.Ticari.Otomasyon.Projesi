using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ProductManager PM = new ProductManager(new EfProductDal());
        public ActionResult Index()
        {
            var deger = PM.GetList();
            return View(deger);
        }
    }
}