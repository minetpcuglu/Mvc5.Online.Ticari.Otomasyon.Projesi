using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        BillPenManager BpM = new BillPenManager(new EfBillPenDal());
        Context c = new Context();
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

        public ActionResult DinamicBill()
        {
            DinamicBillDTO db = new DinamicBillDTO();
            db.bills = c.Bills.ToList();
            db.billPens = c.BillPens.ToList();
            return View(db);
        }

        public ActionResult SaveBill(string BillSerialNo, string BillSıraNo, DateTime Date, string TaxAdministration, string Hour, string Deliveryarea, string Submitter, string Totel,
            BillPen[] billPens)
        {
            Bill b = new Bill();
            b.BillSerialNo = BillSerialNo;
            b.BillSıraNo = BillSıraNo;
            b.Date = Date;
            b.TaxAdministration = TaxAdministration;
            b.Hour = Hour;
            b.Deliveryarea = Deliveryarea;
            b.Submitter = Submitter;
            b.Totel = decimal.Parse(Totel);
            c.Bills.Add(b);

            foreach (var x in billPens)

            {
                BillPen bp = new BillPen();
                bp.Description = x.Description;
                bp.UnitPrice = x.UnitPrice;
                bp.Piece = x.Piece;
                bp.BillId= x.BillPenId;
                bp.Amount = x.Amount;
                c.BillPens.Add(bp);
                
            }
            c.SaveChanges();

           


            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }





    }
}