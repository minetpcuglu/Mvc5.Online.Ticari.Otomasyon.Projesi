using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5.Online.Ticari.Otomasyon.Projesi.Controllers
{
    public class ProductDetailController : Controller
    {
        ProductManager PM = new ProductManager(new EfProductDal());
        Context c = new Context();
        // GET: ProductDetail
        public ActionResult Index()
        {
            ProductDTO productDTO = new ProductDTO();
            //var deger = PM.GetList().Where(x=>x.ProductId==1).ToList();
            productDTO.productDto = c.Products.Where(x => x.ProductId == 1).ToList();
            productDTO.ProductDto2 = c.PDetails.Where(y => y.DetailId == 1).ToList();
                 
            return View(productDTO);
        }
    }
}