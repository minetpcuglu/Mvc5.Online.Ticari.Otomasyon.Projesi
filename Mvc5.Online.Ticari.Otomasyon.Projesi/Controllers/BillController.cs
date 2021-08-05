using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        BillManager BM = new BillManager(new EfBillDal());
        public ActionResult Index(int sayfa = 1)
        {
            var deger = BM.GetList().ToPagedList(sayfa, 8);
            return View(deger);
        }
        [HttpGet]
        public ActionResult BillAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BillAdd(Bill b)  // kuralları controllerda gercekleştirdik 
        {
            BM.BillAdd(b);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateBillPage(int id)
        {
            var deger = BM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateBillPage(Bill d)
        {
           
            BM.UpdateBill(d);
            return RedirectToAction("Index");
        }







    }
}