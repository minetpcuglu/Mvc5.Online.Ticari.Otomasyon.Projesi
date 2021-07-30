using BusinessLayer;
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
    public class ProductController : Controller
    {
        // GET: Product

        ProductManager PM = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ProductValidator rules = new ProductValidator();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductList()
        {
            var deger = PM.GetList();
           
            return View(deger);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {


            ////DROPDOWNLİST   categoriler için 
            ////ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueCategory = (from x in cm.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.CategoryName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.CategoryId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueCategory;  //tasımak için 

            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            
            
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                PM.ProductAdd(p);
                return RedirectToAction("GetProductlist");
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

        public ActionResult ProductDelete(int id)
        {
            //durumu false true yapmak için
            var deger = PM.GetById(id); //ıd ye göre bul
            deger.Status = false;
       
            PM.ProductDelete(deger);

            return RedirectToAction("GetProductList");

        }

        [HttpGet]
        public ActionResult ProductUpdatePage(int id)
        {
            ////DROPDOWNLİST   categoriler için 
            ////ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueCategory = (from x in cm.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.CategoryName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.CategoryId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueCategory;  //tasımak için 

            var deger = PM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult ProductUpdatePage(Product p)
        {
            p.Status = true;
            PM.ProductUpdate(p);
           
         
            return RedirectToAction("GetProductList");
        }


       public ActionResult Documents()
        {
            return View();
        }

        public ActionResult ProductPdf()
        {
            var deger = PM.GetList();
            return View(deger);
        }

       

      
    }
}