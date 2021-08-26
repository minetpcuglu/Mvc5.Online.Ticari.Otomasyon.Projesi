using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    [Authorize]
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        CurrentManager cm = new CurrentManager(new EfCurrentDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        CargoDetailManager CDM = new CargoDetailManager(new EfCargoDetailDal());
        CargoTrackingManager TCM = new CargoTrackingManager(new EfCargoTrackingDal());
        SalesMovementsManager SMM = new SalesMovementsManager(new EfSalesMovementsDal());
        Context c = new Context();

        
        public ActionResult Index()
        {
            var carimail = (string)Session["CurrentMail"];
            var deger = mm.GetList().Where(x => x.ReceiverMail == carimail).ToList();
            var mailId = cm.GetList().Where(x => x.CurrentMail == carimail).Select(y => y.CurrentId).FirstOrDefault();
            var toplamsatıs = SMM.GetList().Where(x => x.CurrentId == mailId).Count();
            var toplamtutar = SMM.GetList().Where(x => x.CurrentId == mailId).Sum(y => y.TotelPrice);
            var toplamurunsayısı = SMM.GetList().Where(x => x.CurrentId == mailId).Sum(y => y.Piece);
            var adsoyad = cm.GetList().Where(x => x.CurrentMail == carimail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            var sehir = cm.GetList().Where(x => x.CurrentMail == carimail).Select(y => y.CurrentCity).FirstOrDefault();

            ViewBag.sehir = sehir;
            ViewBag.adsoyad = adsoyad;
            ViewBag.toplamtutar = toplamtutar;
            ViewBag.toplamurunsayısı = toplamurunsayısı;
            ViewBag.toplamsatis = toplamsatıs;
            ViewBag.mail = mailId;
            ViewBag.m = carimail;
            return View(deger);
        }

        public ActionResult MyOrders()
        {
            var carimail = (string)Session["CurrentMail"];
            var id = cm.GetList().Where(x => x.CurrentMail == carimail.ToString()).Select(y => y.CurrentId).FirstOrDefault();

            var deger = SMM.GetList().Where(x => x.CurrentId == id).ToList();
            return View(deger);
        }

        public ActionResult CargoFallow(string p)
        {
            var deger = from x in CDM.GetList() select x;
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(y => y.TrackingCode.Contains(p));
            }
            return View(deger.ToList());
    
        }
        public ActionResult CurrentCargoDetail(string id) //route config detayı id yapıldı
        {
            var deger = TCM.GetListCargoDetail(id);
            return View(deger);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult CurrentProfilPartial()
        {
            var carimail = (string)Session["CurrentMail"];
            var id = cm.GetList().Where(x => x.CurrentMail == carimail).Select(y => y.CurrentId).FirstOrDefault();
            var profilbul = c.Currents.Find(id);
            return PartialView("CurrentProfilPartial",profilbul);
        }

        public PartialViewResult CurrentDuyurularPartial()
        {
            var veriler = mm.GetList().Where(x => x.SenderMail == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult UpdateCurrentPassword(Current c)
        {
            c.CurrentStatus = true;
            cm.UpdateCurrent(c);
            return RedirectToAction("Index");
        }

    }
}