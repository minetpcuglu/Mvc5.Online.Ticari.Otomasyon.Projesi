using DataAccessLayer.Concrete;
using Mvc5.Online.Ticari.Otomasyon.Projesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class GraphController : Controller
    {
        Context c = new Context();
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList3(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }
        public List<CategoryVM> BlogList3()
        {
            List<CategoryVM> writerVMs = new List<CategoryVM>();
            writerVMs = c.Categories.Select(x => new CategoryVM
            {
                CategoryName = x.CategoryName,
                ProductCount = x.Products.Count,

            }).ToList();

            return writerVMs;
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult EmployeeChart()
        {
            return Json(BlogList2(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }
        public List<EmployeeVM> BlogList2()
        {
            List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
            employeeVMs = c.Departmants.Select(x => new EmployeeVM
            {
               DepartmantName = x.DepartmantName,
                Employee = x.Employees.Count,

            }).ToList();

            return employeeVMs ;
        }

        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult CurrentChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }
        public List<CurrentVM> BlogList()
        {
            List<CurrentVM> currentVMs = new List<CurrentVM>();
           currentVMs = c.Employees.Select(x => new CurrentVM
            {
                EmployeesName = x.EmployeeName,
                Sales = x.Sales.Count,

            }).ToList();

            return currentVMs;
        }
    }
}