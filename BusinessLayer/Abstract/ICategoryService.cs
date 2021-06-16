using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);//categoryden eklemek için bir tanım yapıldı

        void DeleteCategory(Category category); //silme işlemi 
        Category GetById(int id);  //dısarıdan bir ıd alıcak 

        void UpdateCategory(Category category); //güncelleme işlemi 

        Category GetByName(string name); //dısarıdan bir isim alıcak
    }
}
