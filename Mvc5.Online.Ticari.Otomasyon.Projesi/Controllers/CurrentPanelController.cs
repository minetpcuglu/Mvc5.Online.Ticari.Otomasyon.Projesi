using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        CurrentManager cm = new CurrentManager(new EfCurrentDal());
        SalesMovementsManager SMM = new SalesMovementsManager(new EfSalesMovementsDal());

        [Authorize]
        public ActionResult Index()
        {
            var carimail = (string)Session["CurrentMail"];
            var deger = cm.GetList().FirstOrDefault(x => x.CurrentMail == carimail);
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


    }
}