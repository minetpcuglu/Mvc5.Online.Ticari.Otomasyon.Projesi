using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    [Authorize]
    public class DepartmantController : Controller
    {
        // GET: Departmant
        DepartmantManager DM = new DepartmantManager(new EfDepartmantDal());
       
        DepartmantValidator rules = new DepartmantValidator();
        Context c = new Context();




        public ActionResult Index(int sayfa = 1)
        {
            var deger = DM.GetList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        [HttpGet]
        public ActionResult DepartmantAdd()
        {

            return View();
        }


        [HttpPost]
        public ActionResult DepartmantAdd(Departmant d)
        {
            ValidationResult result = rules.Validate(d);
            if (result.IsValid)
            {
                DM.DepartmantAdd(d);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();






        }

        public ActionResult DepartmantDelete(int id)
        {
            var deger = DM.GetById(id);
            deger.DepartmantStatus = false;
            DM.DepartmantDelete(deger);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateDepartmantPage(int id)
        {
            var deger = DM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateDepartmantPage(Departmant d)
        {
            d.DepartmantStatus = true;
            DM.DepartmantUpdate(d);
            return RedirectToAction("Index");
        }

        

    }
}