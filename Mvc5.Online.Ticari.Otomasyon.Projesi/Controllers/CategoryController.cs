using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;

using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CategoryValidator CV = new CategoryValidator(); //kurallar için nesne türettik  
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var deger = cm.GetList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CategoryAdd(Category c)  //VALİDATOR kuralları controllerda gercekleştirdik 
        {
           
            ValidationResult result = CV.Validate(c); //fluent validaton ekle
            if (result.IsValid)
            {
                cm.CategoryAdd(c);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)  //rsultan gelen errrorlarla döngü olustur eger değilse
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }

        public ActionResult CategoryDelete(int id)
        {
            var deger = cm.GetById(id); //önce id bulunur 
            cm.DeleteCategory(deger);   //sonra silinme işlemi 

            return RedirectToAction("GetCategoryList");

        }

        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var deger = cm.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category c)
        {
            ValidationResult result =CV.Validate(c); //kurallara bakalım
            if (result.IsValid)
            {
                cm.UpdateCategory(c);
                
                return RedirectToAction("GetCategoryList");
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
    }
        
}