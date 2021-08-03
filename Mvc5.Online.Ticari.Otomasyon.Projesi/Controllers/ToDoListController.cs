using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        ToDoListManager tdm = new ToDoListManager(new EfToDoListDal());
        ProductManager PM = new ProductManager(new EfProductDal());
        CurrentManager CM = new CurrentManager(new EfCurrentDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var deger = CM.GetList().Count().ToString();
            ViewBag.d1 = deger;

            var deger2 = PM.GetList().Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = cm.GetList().Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in CM.GetList() select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var degertolist = tdm.GetList();
            return View(degertolist);
        }

        
    }
}