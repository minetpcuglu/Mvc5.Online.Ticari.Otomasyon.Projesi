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
    public class BillPenController : Controller
    {
        BillPenManager BPM = new BillPenManager(new EfBillPenDal());
        BillManager BM = new BillManager(new EfBillDal());
        // GET: BillPen
        public ActionResult Index(int sayfa = 1)
        {
            var deger = BPM.GetList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        public ActionResult BillPenByBill(int id)
        {
            var deger = BPM.GetListBillID(id);
            return View(deger);
        }

        [HttpGet]
        public ActionResult BillAdd()
        {
            List<SelectListItem> ValueBill = (from x in BM.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.BillSerialNo,       //valuenumber = secilen degerin ıd si
                                                      Value = x.BillId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueBill;  //tasımak için 
            return View();
        }


        [HttpPost]
        public ActionResult BillAdd(BillPen b)  // kuralları controllerda gercekleştirdik 
        {
            BPM.BillPenAdd(b);
            return RedirectToAction("Index");

        }

     
    }
}