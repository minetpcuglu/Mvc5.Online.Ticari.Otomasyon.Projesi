using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());        // GET: Message
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InBox()
        {
            var mail = (string)Session["CurrentMail"];
            var deger = mm.GetList().Where(x => x.ReceiverMail == mail).ToList();
            var gelensayısı = mm.GetList().Count(y => y.ReceiverMail == mail).ToString();
            ViewBag.d1 = gelensayısı;
            return View(deger);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            return View();
        }
    }
}