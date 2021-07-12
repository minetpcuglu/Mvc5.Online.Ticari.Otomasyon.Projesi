using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeManager EM = new EmployeeManager(new EfEmployeeDal());
        public ActionResult Index()
        {
            var deger = EM.GetList();
            return View(deger);
        }

        public ActionResult EmployeeByDepartmant(int id)
        {
            var deger = EM.GetListDepartmantID(id);
            return View(deger);
        }

    }
}