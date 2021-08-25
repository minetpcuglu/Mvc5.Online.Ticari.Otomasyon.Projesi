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
            var deger = mm.GetList().Where(x => x.ReceiverMail == mail).OrderByDescending(x=>x.MessageId).ToList();
            var gelensayısı = mm.GetList().Count(y => y.ReceiverMail == mail).ToString();
            var gonderilensayısı = mm.GetList().Count(y => y.SenderMail == mail).ToString();
            ViewBag.d1 = gelensayısı;
            ViewBag.d2 = gonderilensayısı;
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
            var mail = (string)Session["CurrentMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.SenderMail = mail;
            mm.MessageAdd(m);
            return RedirectToAction("SendBox");
        }

        public ActionResult SendBox()
        {
            var mail = (string)Session["CurrentMail"];
            var deger = mm.GetList().Where(x => x.SenderMail == mail).OrderByDescending(x => x.MessageId).ToList();
            var gelensayısı = mm.GetList().Count(y => y.ReceiverMail == mail).ToString();
            var gonderilensayısı = mm.GetList().Count(y => y.SenderMail == mail).ToString();
            ViewBag.d1 = gelensayısı;
            ViewBag.d2 = gonderilensayısı;
            return View(deger);
        }

        public ActionResult MessageDetail(int id)
        {
            var deger2 = mm.GetList().Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var deger = mm.GetList().Where(x => x.SenderMail == mail).ToList();
            var gelensayısı = mm.GetList().Count(y => y.ReceiverMail == mail).ToString();
            var gonderilensayısı = mm.GetList().Count(y => y.SenderMail == mail).ToString();
            ViewBag.d1 = gelensayısı;
            ViewBag.d2 = gonderilensayısı;
            return View(deger2);
        }
    
    }
}