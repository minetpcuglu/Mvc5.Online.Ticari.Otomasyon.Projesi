using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeManager EM = new EmployeeManager(new EfEmployeeDal());
        DepartmantManager DM = new DepartmantManager(new EfDepartmantDal());
        public ActionResult Index(int sayfa = 1)
        {
            var deger = EM.GetList().ToPagedList(sayfa, 8);
            return View(deger);
        }

        public ActionResult EmployeeByDepartmant(int id)
        {
            var deger = EM.GetListDepartmantID(id);
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            ////ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueEmployee = (from x in DM.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.DepartmantName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.DepartmantId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueEmployee;  //tasımak için 
            
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            if (Request.Files.Count>0) //resim ekleme
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                e.EImage = "/Image/" + dosyaadi + uzanti;
            }
            EM.EmployeeAdd(e);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEmployeePage(int id)
        {
            ////ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueEmployee = (from x in DM.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.DepartmantName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.DepartmantId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueEmployee;  //tasımak için 
            var deger = EM.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateEmployeePage(Employee d)
        {
            if (Request.Files.Count > 0) //resim ekleme
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                d.EImage = "/Image/" + dosyaadi + uzanti;
            }

            EM.EmployeeUpdate(d);
            return RedirectToAction("Index");
        }

        public ActionResult EmployeePdf()
        {
            var deger = EM.GetList();
            return View(deger);
        }

        public ActionResult PersonelDetails()
        {
            var deger = EM.GetList();
            return View(deger);
        }

    }
}