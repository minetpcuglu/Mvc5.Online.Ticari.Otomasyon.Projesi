using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    
    public class SalesMovementsController : Controller
    {
        // GET: SalesMovements
        SalesMovementsManager SMM = new SalesMovementsManager(new EfSalesMovementsDal());
        ProductManager PM = new ProductManager(new EfProductDal());
        EmployeeManager EM = new EmployeeManager(new EfEmployeeDal());
        CurrentManager CM = new CurrentManager(new EfCurrentDal());

        Context c = new Context();
        public ActionResult Index()
        {
            var deger = SMM.GetList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult NewSales()
        {
            List<SelectListItem> degerurun = (from x in PM.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }
                                           ).ToList();

            List<SelectListItem> degercari = (from x in CM.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CurrentName + " " + x.CurrentSurname ,
                                                  Value = x.CurrentId.ToString()
                                              }
                                         ).ToList();

            List<SelectListItem> degerpersonel = (from x in EM.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                  Value = x.EmployeeId.ToString()
                                              }
                                         ).ToList();

            ViewBag.deger = degerurun;
            ViewBag.deger2 = degercari;
            ViewBag.deger3 = degerpersonel;


            return View();
        }

        [HttpPost]
        public ActionResult NewSales(SalesMovements s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            SMM.SalesMovementAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult SalesMovementsByEmployee(int id)
        {
            var deger = SMM.GetListEmployeeID(id);

            return View(deger);
        }

        public ActionResult SalesMovementsByCurrent(int id)
        {
            
            var deger = SMM.GetListCurrentID(id);
            var cr = c.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = cr;


            return View(deger);
        }

        [HttpGet]
        public ActionResult SalesMovementsUpdatePage(int id)
        {
            List<SelectListItem> degerurun = (from x in PM.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.ProductName,
                                                  Value = x.ProductId.ToString()
                                              }
                                           ).ToList();

            List<SelectListItem> degercari = (from x in CM.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.CurrentName + " " + x.CurrentSurname,
                                                  Value = x.CurrentId.ToString()
                                              }
                                         ).ToList();

            List<SelectListItem> degerpersonel = (from x in EM.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                      Value = x.EmployeeId.ToString()
                                                  }
                                         ).ToList();

            ViewBag.deger = degerurun;
            ViewBag.deger2 = degercari;
            ViewBag.deger3 = degerpersonel;



            var deger = SMM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult SalesMovementsUpdatePage(SalesMovements p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            SMM.SalesMovementUpdate(p);
          

            return RedirectToAction("Index");
        }


        public ActionResult SalesMovementsDetails(int id)
        {
            var deger = SMM.SalesMovementsDetail(id);

            return View(deger);
        }

        public ActionResult SalesMovementsPdf()
        {
            var deger = SMM.GetList();
            return View(deger);
        }
    }

}