using BusinessLayer.Concrete;
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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        CurrentManager cm = new CurrentManager(new EfCurrentDal());
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Partial1(Current c)
        {
            cm.CurrentAdd(c);
            return PartialView();
        }

        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CurrentLogin(Current a)
        {
            var bilgiler = cm.GetCurrent(a.CurrentMail, a.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
                Session["CurrentMail"] = bilgiler.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult     AdminLogin(Admin a)
        {
            var bilgiler = adm.GetAdmin(a.UserName , a.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                Session["UserName"] = bilgiler.UserName.ToString();
                return RedirectToAction("GetCategoryList", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}