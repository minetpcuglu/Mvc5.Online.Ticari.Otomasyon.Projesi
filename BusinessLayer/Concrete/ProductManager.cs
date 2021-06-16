using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public List<Product> GetList()
        {
            return _productDal.List().Where(x => x.Status == true).ToList();
        }


        public void ProductAdd(Product product)
        {
            product.Status = true;
            _productDal.Insert(product);
            
        }

        public void ProductDelete(Product product)
        {
            _productDal.Update(product);
        }

        public void ProductUpdate(Product product)
        {
          
            _productDal.Update(product);
   
        }
    }
}
