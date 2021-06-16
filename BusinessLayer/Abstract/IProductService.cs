using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
         void ProductDelete(Product product);
        void ProductUpdate(Product product);
        void ProductAdd(Product product);
        List<Product> GetList();
        //List<Product> GetListStatus();
        Product GetById(int id);
    }
}
