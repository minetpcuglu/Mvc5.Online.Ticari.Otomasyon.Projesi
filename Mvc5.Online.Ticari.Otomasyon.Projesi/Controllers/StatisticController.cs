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
    public class StatisticController : Controller
    {
        // GET: Statistic
        ProductManager PM = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        SalesMovementsManager SMM = new SalesMovementsManager(new EfSalesMovementsDal());
        EmployeeManager EM = new EmployeeManager(new EfEmployeeDal());
        CurrentManager CM = new CurrentManager(new EfCurrentDal());
        DepartmantManager DM = new DepartmantManager(new EfDepartmantDal());
        public ActionResult Index()
        {
            var degerCariSayısı = cm.GetList().Count().ToString();
            var degerUrunSayısı = PM.GetList().Count().ToString();
            var degerPersonelSayısı = EM.GetList().Count().ToString();
            var degerKategoriSayısı = cm.GetList().Count().ToString();
            var degerStokSayısı = PM.GetList().Sum(x => x.UnitInStok).ToString();
            var degerMarkaSayısı = (from x in PM.GetList() select x.Brand).Distinct().Count().ToString(); //sseçilen markayı tekrarsız say
            var degerKritikurunSayısı = (from x in PM.GetList() orderby x.UnitInStok ascending select x.ProductName).FirstOrDefault();
            var degerMaxFiyaturun = (from x in PM.GetList() orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            var degerMinFiyaturun = (from x in PM.GetList() orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            var degerBuzdolabısayısı = PM.GetList().Count(x => x.ProductName == "Buzdolabı").ToString();
            var degerPcsayısı = PM.GetList().Count(x => x.ProductName == "Laptop").ToString();
            var degerKasaTutar = SMM.GetList().Sum(x => x.TotelPrice).ToString();

            DateTime bugun = DateTime.Today;
            var degerbugunyapılansatış = SMM.GetList().Count(x => x.Date == bugun).ToString();
            var degerbugunKasa = SMM.GetList().Where(x => x.Date == bugun).Sum(y => y.TotelPrice).ToString();

            var degerencokismigecenmarka = PM.GetList().GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();

            var degerencoksatan = PM.GetList().Where(t => t.ProductId == (SMM.GetList().GroupBy(x => x.ProductId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            //satıs hareket tablosu uzerınde en cok gecen tablonun ıd ıs smm sorgusu diğeride ıd nin adını ver 




            ViewBag.d1 = degerCariSayısı;
            ViewBag.d2 = degerUrunSayısı;
            ViewBag.d3 = degerPersonelSayısı;
            ViewBag.d4 = degerKategoriSayısı;
            ViewBag.d5 = degerStokSayısı;
            ViewBag.d6 = degerMarkaSayısı;
            ViewBag.d7 = degerKritikurunSayısı;
            ViewBag.d8 = degerMaxFiyaturun;
            ViewBag.d9 = degerMinFiyaturun;
            ViewBag.d10 = degerBuzdolabısayısı;
            ViewBag.d11 = degerPcsayısı;
            ViewBag.d14 = degerKasaTutar;
            ViewBag.d15 = degerbugunyapılansatış;
            ViewBag.d16 = degerbugunKasa;
            ViewBag.d12 = degerencokismigecenmarka;
            ViewBag.d13 = degerencoksatan;

            return View();
        }



        public ActionResult SmplesTable()
        {
            var sorgu = from x in CM.GetList()
                        group x by x.CurrentCity into g
                        select new SımpleTableDTO
                        {
                            City = g.Key,
                            TotelEmployee = g.Count(),
                        };
            return View(sorgu);
        }


        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in EM.GetList()
                         group x by x.Departmant.DepartmantName
                         into g
                         select new SımpleTable2
                         {
                             depname= g.Key,
                            DepId = g.Count(),
                         };

            return PartialView(sorgu2);
        }

        public PartialViewResult Partial5()
        {
            var sorgu2 = from x in PM.GetList()
                         group x by x.Category.CategoryName
                         into g
                         select new SimpleTable4
                         {
                             Pname = g.Key,
                             Piece = g.Count(),
                         };

            return PartialView(sorgu2);
        }

        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in PM.GetList()
                         group x by x.Brand
                         into g
                         select new SimpleTable3
                         {
                            Brand = g.Key,
                             BrandNumber = g.Count(),
                         };

            return PartialView(sorgu5);
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = CM.GetList();

            return PartialView(sorgu3);
        }

        public PartialViewResult Partial3()
        {
            var sorgu4 = PM.GetList();

            return PartialView(sorgu4);
        }
    }
}