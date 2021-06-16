using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void ContactAdd(Admin admin);//categoryden eklemek için bir tanım yapıldı

        Admin GetById(int id);  //dısarıdan bir ıd alıcak

        void DeleteAdmin(Admin admin); //silme işlemi

        void UpdateAdmin(Admin admin); //güncelleme işlemi 
    }
}
