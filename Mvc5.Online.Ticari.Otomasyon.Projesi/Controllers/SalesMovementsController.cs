using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    
    public class SalesMovementsController : Controller
    {
        // GET: SalesMovements
        SalesMovementsManager SMM = new SalesMovementsManager(new EfSalesMovementsDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesMovementsByEmployee(int id)
        {
            var deger = SMM.GetListEmployeeID(id);

            return View(deger);
        }
    }
}